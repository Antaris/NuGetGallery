using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace NuGetGallery.Xml
{
    public class XDocumentResult : ActionResult
    {
        private readonly XDocument _document;

        public XDocumentResult(XDocument document)
        {
            _document = document;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Grab the HTTP response.
            var response = context.HttpContext.Response;

            // Set the content type and encoding.
            response.ContentType = "text/xml";
            response.HeaderEncoding = Encoding.UTF8;

            using (var writer = new XmlTextWriter(response.OutputStream, Encoding.UTF8) { Formatting = Formatting.Indented })
            {
                // Write the document to the output stream.
                _document.WriteTo(writer);
            }
        }
    }
}