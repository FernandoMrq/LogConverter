using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using CandidateTesting.FernandoMarques.Infra;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Adapters.Integration
{
    public class MinhaCDNAddapter : IInputAddapter
    {
        private readonly IWebClient _client;

        public MinhaCDNAddapter(IWebClient client)
        {
            _client = client;
        }

        public async Task<List<string>> GetLogList(string url)
        {
            try
            {
                var logLines = new List<string>();
                var content = _client.DownloadData(url);
                var memoryStream = new MemoryStream(content);
                var streamReader = new StreamReader(memoryStream);
                string line;
                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    logLines.Add(line);
                }

                return logLines;
            }
            catch (System.Exception)
            {
                return default;
            }
        }
    }
}
