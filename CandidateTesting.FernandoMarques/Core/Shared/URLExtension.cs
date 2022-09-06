using System;

namespace CandidateTesting.FernandoMarques.Core.Shared
{
    public static class URLExtension
    {
        public static bool IsUrlFormat(this string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
