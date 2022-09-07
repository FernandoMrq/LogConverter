using System.IO;

namespace CandidateTesting.FernandoMarques.Core.Domain.Business
{
    public interface ILogConverterBusiness
    {
        public Stream DownloadLog(string url);
        public void MakeNewFile(Stream file, string filePatch);
    }
}
