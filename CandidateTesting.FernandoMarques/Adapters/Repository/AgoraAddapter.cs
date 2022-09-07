using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Adapters.Repository
{
    public class AgoraAddapter : IOutputAddapter
    {
        public Task<bool> SaveFile(List<string> content, string filePatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
