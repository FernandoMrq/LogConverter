using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Core.Domain.Adapters
{
    public interface IInputAddapter
    {
        public Task<List<string>> GetLogList(string url);
    }
}
