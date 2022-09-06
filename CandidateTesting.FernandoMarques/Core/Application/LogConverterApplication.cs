using CandidateTesting.FernandoMarques.Core.Domain.Business;
using CandidateTesting.FernandoMarques.Core.Shared;

namespace CandidateTesting.FernandoMarques.Core.Application
{
    public class LogConverterApplication : ILogConverterApplication
    {
        private readonly IConsoleBusiness _consoleBusiness;
        private readonly ILogConverterBusiness _logConverterBusiness;


        public LogConverterApplication(IConsoleBusiness consoleBusiness
            , ILogConverterBusiness logConverterBusiness)
        {
            _consoleBusiness = consoleBusiness;
            _logConverterBusiness = logConverterBusiness;
        }

        public void StartConverterLog()
        {
            while (_consoleBusiness.StayOpen())
            {
                _consoleBusiness.MakeDialogMenu();

                string userInput = _consoleBusiness.GetUserInput();

                //TODO colocar para quebrar a string e pegar o penultimo membro
                var url = _consoleBusiness.GetURL(userInput);
                if (!url.IsUrlFormat())
                {
                    _consoleBusiness.SendMalformedURLMessage();
                    continue;
                }

                var file = _logConverterBusiness.DownloadLog(url);
                var newFile = _logConverterBusiness.MakeNewFile(file);

                _consoleBusiness.SendResultMessage(newFile);
            }
        }
    }
}
