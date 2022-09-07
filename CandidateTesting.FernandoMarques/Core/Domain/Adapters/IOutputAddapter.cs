using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Core.Domain.Adapters
{
    public interface IOutputAddapter
    {
        public Task SaveFile(List<string> content, string filePatch);
    }
}
