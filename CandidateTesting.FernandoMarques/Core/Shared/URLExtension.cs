using System;
using System.Diagnostics.CodeAnalysis;

namespace CandidateTesting.FernandoMarques.Core.Shared
{
    [ExcludeFromCodeCoverage]
    public static class URLExtension
    {
        public static bool IsUrlFormat(this string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
