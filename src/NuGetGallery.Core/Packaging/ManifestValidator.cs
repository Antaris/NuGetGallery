// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using NuGet.Packaging;

namespace NuGetGallery.Packaging
{
    public class ManifestValidator
    {
        // Copy-pasta from NuGet: src/Core/Utility/PackageIdValidator.cs because that constant is internal :(
        public static readonly int MaxPackageIdLength = 100;
        
        public static IEnumerable<ValidationResult> Validate(Stream nuspecStream, out NuspecReader nuspecReader)
        {
            try
            {
                nuspecReader = new NuspecReader(nuspecStream);
                var rawMetadata = nuspecReader.GetMetadata();
                if (rawMetadata != null && rawMetadata.Any())
                {
                    return ValidateCore(PackageMetadata.FromNuspecReader(nuspecReader));
                }
            }
            catch (Exception ex)
            {
                nuspecReader = null;
                return new [] { new ValidationResult(ex.Message) };
            }

            return Enumerable.Empty<ValidationResult>();
        }

        private static IEnumerable<ValidationResult> ValidateCore(PackageMetadata packageMetadata)
        {
            // Validate the ID
            if (string.IsNullOrEmpty(packageMetadata.Id))
            {
                yield return new ValidationResult(Strings.Manifest_MissingId);
            }
            else
            {
                if (packageMetadata.Id.Length > MaxPackageIdLength)
                {
                    yield return new ValidationResult(Strings.Manifest_IdTooLong);
                }
                else if (!PackageIdValidator.IsValidPackageId(packageMetadata.Id))
                {
                    yield return new ValidationResult(String.Format(
                        CultureInfo.CurrentCulture,
                        Strings.Manifest_InvalidId,
                        packageMetadata.Id));
                }
            }

            // Check URL properties
            foreach (var result in CheckUrls(
                packageMetadata.GetValueFromMetadata("IconUrl"),
                packageMetadata.GetValueFromMetadata("ProjectUrl"), 
                packageMetadata.GetValueFromMetadata("LicenseUrl")))
            {
                yield return result;
            }

            // Check version
            if (packageMetadata.Version == null)
            {
                var version = packageMetadata.GetValueFromMetadata("version");

                yield return new ValidationResult(String.Format(
                    CultureInfo.CurrentCulture,
                    Strings.Manifest_InvalidVersion,
                    version));
            }

            // Check dependency groups
            // review-2720 this should throw/return a list of parse errors instead of silently ignoring faulty frameworks. or should it?
            var dependencyGroups = packageMetadata.GetDependencyGroups();
            //if (dependencyGroups != null)
            //{
            //    foreach (var dependency in dependencyGroups.SelectMany(set => set.Packages))
            //    {
            //        VersionRange ___;
            //        if (!PackageIdValidator.IsValidPackageId(dependency.Id) || ( !string.IsNullOrEmpty(dependency.VersionRange.) && !VersionUtility.TryParseVersionSpec(dependency.Version, out ___)))
            //        {
            //            yield return new ValidationResult(String.Format(
            //                CultureInfo.CurrentCulture,
            //                Strings.Manifest_InvalidDependency,
            //                dependency.Id,
            //                dependency.Version));
            //        }
            //    }
            //}

            // Check frameworks
            // review-2720 this should throw/return a list of parse errors instead of silently ignoring faulty frameworks. or should it?
            var frameworkReferences = packageMetadata.GetFrameworkReferenceGroups();
            //var fxes = Enumerable.Concat(
            //    frameworkReferences == null ? 
            //        Enumerable.Empty<NuGetFramework>() : 
            //        (frameworkReferences.Select(a => a.TargetFramework)),
            //    dependencyGroups == null ?
            //        Enumerable.Empty<NuGetFramework>() :
            //        (dependencyGroups.Select(s => s.TargetFramework)));
            //foreach (var fx in fxes)
            //{
            //    //if target framework is not specified, then continue. Validate only for wrong specification.
            //    if (string.IsNullOrEmpty(fx))
            //        continue;
            //    ValidationResult result = null;
            //    try
            //    {
            //        VersionUtility.ParseFrameworkName(fx);
            //    }
            //    catch (ArgumentException)
            //    {
            //        // Can't yield in the body of a catch...
            //        result = new ValidationResult(String.Format(
            //            CultureInfo.CurrentCulture,
            //            Strings.Manifest_InvalidTargetFramework,
            //            fx));
            //    }

            //    if (result != null)
            //    {
            //        yield return result;
            //    }
            //}
        }

        private static IEnumerable<ValidationResult> CheckUrls(params string[] urls)
        {
            foreach (var url in urls)
            {
                Uri _;
                if (!String.IsNullOrEmpty(url) && !Uri.TryCreate(url, UriKind.Absolute, out _))
                {
                    yield return new ValidationResult(Strings.Manifest_InvalidUrl);
                }
            }
        }
    }
}
