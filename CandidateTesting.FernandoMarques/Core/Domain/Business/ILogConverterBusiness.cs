using System.IO;

namespace CandidateTesting.FernandoMarques.Core.Domain.Business
{
    public interface ILogConverterBusiness
    {
        public Stream DownloadLog(string url);
        public string MakeNewFile(Stream newFile);
    }
}
