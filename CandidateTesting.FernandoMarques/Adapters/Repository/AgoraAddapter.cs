using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Adapters.Repository
{
    public class AgoraAddapter : IOutputAddapter
    {
        public async Task SaveFile(List<string> content, string filePatch)
        {
            var dir = Path.GetDirectoryName(filePatch);

            if (!Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            await File.WriteAllLinesAsync(filePatch, content);
        }
    }
}
