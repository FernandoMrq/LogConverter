using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Core.Domain.Business
{
    public interface ILogConverterBusiness
    {
        public Task<List<string>> DownloadLog(string url);
        public Task MakeNewFile(List<string> content, string filePatch);
    }
}
