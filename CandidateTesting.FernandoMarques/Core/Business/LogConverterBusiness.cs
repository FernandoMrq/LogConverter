using CandidateTesting.FernandoMarques.Core.Domain.Business;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CandidateTesting.FernandoMarques.Core.Business
{
    public class LogConverterBusiness : ILogConverterBusiness
    {
        public Stream DownloadLog(string url)
        {
            var logLines = new List<string>();

            var webClient = new WebClient();
            var content = webClient.DownloadData(url);
            var stream = new MemoryStream(content);
            var sr = new StreamReader(stream);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                logLines.Add(line);
            }
            return default;
            //return logLines;
            //metodo para transformar stream em lista de strings
            //ajustar métodos para receberem lista de strings
        }

        public void MakeNewFile(Stream file, string filePatch)
        {
            throw new System.NotImplementedException();
        }

        private Stream ConvertLog(Stream file)
        {
            throw new System.NotImplementedException();
        }

        private bool SaveNewFile(Stream newFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
