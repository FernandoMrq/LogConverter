using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Adapters.Integration
{
    public class MinhaCDNAddapter : IInputAddapter
    {
        public async Task<List<string>> GetLogList(string url)
        {
            var logLines = new List<string>();
            var webClient = new WebClient();
            var content = webClient.DownloadData(url);
            var stream = new MemoryStream(content);
            var sr = new StreamReader(stream);
            string line;
            while ((line = await sr.ReadLineAsync()) != null)
            {
                logLines.Add(line);
            }

            return logLines;
        }
    }
}
