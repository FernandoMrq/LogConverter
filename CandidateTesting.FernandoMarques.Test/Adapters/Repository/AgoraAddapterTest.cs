using AutoFixture;
using CandidateTesting.FernandoMarques.Adapters.Repository;
using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Xunit;

namespace CandidateTesting.FernandoMarques.Test.Adapters.Repository
{
    [ExcludeFromCodeCoverage]
    public class AgoraAddapterTest
    {
        private readonly IOutputAddapter _outputAddapter;
        private readonly Fixture _fixture;
        private readonly IFileSystem _fileSystem;

        public AgoraAddapterTest()
        {
            _fixture = new Fixture();
            _fileSystem = Substitute.For<IFileSystem>();
            _outputAddapter = new AgoraAddapter(_fileSystem);
        }

        [Fact]
        public async void SaveFile_ShouldCreateDirectory_WhenDirectoryDoesNotExist()
        {
            //Arrange
            _fileSystem.Directory.Exists(Arg.Any<string>())
                .Returns(false);

            _fileSystem.File.WriteAllLinesAsync(Arg.Any<string>(), Arg.Any<List<string>>())
                .Returns(Task.CompletedTask);

            var filePatch = _fixture.Create<string>();
            var content = _fixture.Create<List<string>>();

            //Act
            var saved = await _outputAddapter.SaveFile(content, filePatch);

            //Assert
            saved.Should().BeTrue();
        }

        [Fact]
        public async void SaveFile_ShouldReturnFalse_WhenThrowException()
        {
            //Arrange
            _fileSystem.Directory.Exists(Arg.Any<string>()).Returns(true);
            _fileSystem.File.WriteAllLinesAsync(Arg.Any<string>(), Arg.Any<List<string>>())
                .Throws(new IOException());

            var filePatch = _fixture.Create<string>();
            var content = _fixture.Create<List<string>>();

            //Act
            var saved = await _outputAddapter.SaveFile(content, filePatch);

            //Assert
            saved.Should().BeFalse();
        }
    }
}
