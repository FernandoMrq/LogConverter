using CandidateTesting.FernandoMarques.Core.Domain.Business;
using CandidateTesting.FernandoMarques.Core.Domain.Resources;
using CandidateTesting.FernandoMarques.Core.Shared;

namespace CandidateTesting.FernandoMarques.Core.Application
{
    public class LogConverterApplication : ILogConverterApplication
    {
        private readonly ILogConverterBusiness _logConverterBusiness;

        public LogConverterApplication(ILogConverterBusiness logConverterBusiness)
        {
            _logConverterBusiness = logConverterBusiness;
        }

        public async void StartConverterLog(string[] args)
        {
            if (args.Length != int.Parse(IndexArgResource.Count))
                return;

            var url = args[int.Parse(IndexArgResource.URL)];
            var patch = args[int.Parse(IndexArgResource.Patch)];

            if (!url.IsUrlFormat())
                return;

            var content = await _logConverterBusiness.DownloadLog(url);

            await _logConverterBusiness.MakeNewFile(content, patch);
        }
    }
}
