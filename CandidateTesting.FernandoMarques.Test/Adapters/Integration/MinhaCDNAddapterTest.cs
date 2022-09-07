using AutoFixture;
using CandidateTesting.FernandoMarques.Adapters.Integration;
using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using NSubstitute;
using System.IO.Abstractions;
using Xunit;

namespace CandidateTesting.FernandoMarques.Test.Adapters.Integration
{
    public class MinhaCDNAddapterTest
    {
        private readonly IInputAddapter _inputAddapter;
        private readonly Fixture _fixture;
        private readonly IFileSystem _fileSystem;
        public MinhaCDNAddapterTest()
        {
            _fixture = new Fixture();
            _fileSystem = Substitute.For<IFileSystem>();
            _inputAddapter = new MinhaCDNAddapter();
        }

        [Fact]
        public async void SaveFile_ShouldCreateDirectory_WhenDirectoryDoesNotExist()
        {
            //Arrange
            //_fileSystem.Directory.Exists(Arg.Any<string>())
            //    .Returns(false);

            //_fileSystem.File.WriteAllLinesAsync(Arg.Any<string>(), Arg.Any<List<string>>())
            //    .Returns(Task.CompletedTask);

            var filePatch = _fixture.Create<string>();
            //var content = _fixture.Create<List<string>>();

            //Act
            var saved = await _inputAddapter.GetLogList(filePatch);

            //Assert
            //saved.Should().BeTrue();
        }
    }
}
