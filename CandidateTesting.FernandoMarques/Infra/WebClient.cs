using System.Diagnostics.CodeAnalysis;

namespace CandidateTesting.FernandoMarques.Infra
{
    [ExcludeFromCodeCoverage]
    public class WebClient : IWebClient
    {
        public byte[] DownloadData(string address)
        {
            byte[] bytes = null;
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                bytes = client.DownloadData(address);
            }
            return bytes;
        }
    }
}
