// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using NuGet.Versioning;

namespace NuGetGallery
{
    /// <summary>
    /// Represents a normalized, spec-compatible (with NuGet extensions), Semantic Version as defined at http://semver.org
    /// </summary>
    public static class NuGetVersionExtensions
    {
        public static string Normalize(string version)
        {
            NuGetVersion parsed;
            if (!NuGetVersion.TryParse(version, out parsed))
            {
                return version;
            }
            return parsed.ToNormalizedString();
        }

        public static string ToNormalizedStringSafe(this NuGetVersion self)
        {
            return self != null ? self.ToNormalizedString() : String.Empty;
        }
    }
}