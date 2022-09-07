using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using CandidateTesting.FernandoMarques.Core.Domain.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Core.Business
{
    public class LogConverterBusiness : ILogConverterBusiness
    {
        private readonly IInputAddapter _inputAddapter;
        private readonly IOutputAddapter _outputAddapter;

        public LogConverterBusiness(IInputAddapter inputAddapter
            , IOutputAddapter outputAddapter)
        {
            _inputAddapter = inputAddapter;
            _outputAddapter = outputAddapter;
        }

        public async Task<List<string>> DownloadLog(string url)
        {
            return await _inputAddapter.GetLogList(url);
        }

        public async Task MakeNewFile(List<string> content, string filePatch)
        {
            var newLog = ConvertLog(content);
            await _outputAddapter.SaveFile(newLog, filePatch);
        }

        private List<string> ConvertLog(List<string> content)
        {
            var newLog = new List<string>();
            MakeHeader(newLog);
            foreach (var line in content)
            {
                var splitByPipe = line.Split("|");
                var splitByBar = splitByPipe[3].Replace("\"", String.Empty).Split("/");
                var splitBySpace = splitByBar[1].Split(" ");
                var roundedTime = (int)Math.Round(decimal.Parse(splitByPipe[4], new NumberFormatInfo() { NumberDecimalSeparator = "." }));

                newLog.Add(
                    "\"MINHA CDN\" " +
                    splitByBar[0] +
                    splitByPipe[1] + " " +
                    "/" + splitBySpace[0] + " " +
                    roundedTime + " " +
                    splitByPipe[0] + " " +
                    splitByPipe[2]
                    );
            }

            return newLog;
        }

        private void MakeHeader(List<string> content)
        {
            content.Add("#Version: 1.0");
            content.Add("#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            content.Add("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
        }
    }
}
