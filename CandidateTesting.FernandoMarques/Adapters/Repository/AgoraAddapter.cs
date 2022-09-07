using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace CandidateTesting.FernandoMarques.Adapters.Repository
{
    public class AgoraAddapter : IOutputAddapter
    {
        private readonly IFileSystem _fileSystem;

        public AgoraAddapter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<bool> SaveFile(List<string> content, string filePatch)
        {
            try
            {
                var dir = _fileSystem.Path.GetDirectoryName(filePatch);

                if (!_fileSystem.Directory.Exists(dir))
                    _fileSystem.Directory.CreateDirectory(dir);

                await _fileSystem.File.WriteAllLinesAsync(filePatch, content);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
