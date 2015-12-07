using NuGetGallery.Packaging;
using NuGetGallery.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace NuGetGallery.Controllers
{
    public class ExtensionsController : Controller
    {
        private readonly ISearchService _searchService;
        public IFileStorageService _fileStorageService;

        public ExtensionsController(
            ISearchService searchService, 
            IFileStorageService fileStorageService)
        {
            _searchService = searchService;
            _fileStorageService = fileStorageService;
        }

        public async Task<XDocumentResult> Feed()
        {
            var doc = await CreateFeedDocument();

            return new XDocumentResult(doc);
        }

        public async Task<ActionResult> VsixContent(string id, string version)
        {
            string fileName = string.Format(Constants.PackageFileSavePathTemplate, id.ToLower(), version.ToLower(), Constants.NuGetPackageFileExtension);
            var file = await _fileStorageService.GetFileReferenceAsync(Constants.PackagesFolderName, fileName);
            if (file == null)
            {
                return HttpNotFound();
            }

            using (var stream = file.OpenRead())
            {
                using (var pkg = new Nupkg(stream, true))
                {
                    string embeddedFileName = pkg.GetFiles().FirstOrDefault(f => Path.GetExtension(f).Equals(".vsix", StringComparison.OrdinalIgnoreCase));

                    var vsix = pkg.GetFileStream(embeddedFileName);
                    if (vsix != null)
                    {
                        return new FileStreamResult(vsix, "application/octet-stream")
                        {
                            FileDownloadName = Path.GetFileName(embeddedFileName)
                        };
                    }
                }
            }

            return HttpNotFound();
        }

        private async Task<XDocument> CreateFeedDocument()
        {
            var filter = SearchAdaptor.GetSearchFilter(string.Empty, 1, null, SearchFilter.UISearchContext);
            var results = await _searchService.Search(filter);

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "false"));

            XNamespace atom = "http://www.w3.org/2005/Atom";
            XNamespace vsix = "http://schemas.microsoft.com/developer/vsx-syndication-schema/2010";

            var root = new XElement(atom + "feed");
            doc.Add(root);
            root.Add(new XElement(atom + "title", new XAttribute("type", "text"), "My Extension Gallery"));
            root.Add(new XElement(atom + "id", "My Extension Gallery"));

            if (results.Data.Any())
            {
                var updated = results.Data.Max(p => p.Published);
                root.Add(new XElement(atom + "updated", updated.ToString("yyyy-MM-ddTHH:mm:ssZ")));
            }

            foreach (var package in results.Data)
            {
                var entry = new XElement(atom + "entry");
                entry.Add(new XElement(atom + "id", package.PackageRegistration.Id));
                entry.Add(new XElement(atom + "title", new XAttribute("type", "text"), package.Title));
                entry.Add(new XElement(atom + "summary", new XAttribute("type", "text"), package.Description));
                entry.Add(new XElement(atom + "published", package.Published.ToString("yyyy-MM-ddTHH:mm:ssZ")));
                entry.Add(new XElement(atom + "updated", package.Created.ToString("yyyy-MM-ddTHH:mm:ssZ")));
                entry.Add(new XElement(atom + "author", new XElement(atom + "name", package.FlattenedAuthors)));

                if (!string.IsNullOrWhiteSpace(package.IconUrl))
                {
                    entry.Add(new XElement(atom + "link", new XAttribute("rel", "icon"), new XAttribute("type", "text"), new XAttribute("href", package.IconUrl)));
                }

                if (!string.IsNullOrWhiteSpace(package.ProjectUrl))
                {
                    entry.Add(new XElement(atom + "link", new XAttribute("rel", "alternate"), new XAttribute("type", "text/html"), new XAttribute("href", package.ProjectUrl)));
                }

                var tags = (package.Tags ?? "").Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim());
                foreach (string tag in tags)
                {
                    entry.Add(new XElement(atom + "category", new XAttribute("term", tag)));
                }

                entry.Add(new XElement(atom + "content",
                    new XAttribute("type", "application/octet-stream"),
                    new XAttribute("src", Url.RouteUrl("ExtensionV1Content", new { id = package.PackageRegistration.Id, version = package.NormalizedVersion }))));

                var ext = new XElement(vsix + "Vsix",
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XElement(vsix + "Id", package.PackageRegistration.Id),
                    new XElement(vsix + "Version", package.NormalizedVersion));

                entry.Add(ext);

                root.Add(entry);
            }

            return doc;
        }
    }
}