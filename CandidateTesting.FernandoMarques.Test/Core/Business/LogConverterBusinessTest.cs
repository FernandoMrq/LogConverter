using AutoFixture;
using CandidateTesting.FernandoMarques.Core.Business;
using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using CandidateTesting.FernandoMarques.Core.Domain.Business;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace CandidateTesting.FernandoMarques.Test.Core.Business
{
    public class LogConverterBusinessTest
    {
        private readonly ILogConverterBusiness _logConverterBusiness;
        private readonly IInputAddapter _inputAddapter;
        private readonly IOutputAddapter _outputAddapter;
        private readonly Fixture _fixture;

        public LogConverterBusinessTest()
        {
            _fixture = new Fixture();
            _inputAddapter = Substitute.For<IInputAddapter>();
            _outputAddapter = Substitute.For<IOutputAddapter>();
            _logConverterBusiness = new LogConverterBusiness(_inputAddapter, _outputAddapter);
        }

        [Fact]
        public async void DownloadLog_ShouldComplete_WhenAllIsOk()
        {
            //Arrange
            var url = _fixture.Create<string>();
            var mockedLog = GetMockedLog();

            _inputAddapter.GetLogList(Arg.Any<string>())
                .Returns(mockedLog);

            //Act
            var log = await _logConverterBusiness.DownloadLog(url);

            //Assert
            log.Should().NotBeNull();
            log.Should().BeEquivalentTo(mockedLog);
        }

        [Fact]
        public async void MakeNewFile_ShouldComplete_WhenAllIsOk()
        {
            //Arrange
            var filePatch = _fixture.Create<string>();
            var mockedLog = GetMockedLog();

            //Act
            await _logConverterBusiness.MakeNewFile(mockedLog, filePatch);

            //Assert
            await _outputAddapter.Received(1).SaveFile(Arg.Any<List<string>>(), Arg.Any<string>());
        }

        [Fact]
        public async void MakeNewFile_ShouldNotComplete_WhenHaveProblemInConverter()
        {
            //Arrange
            var filePatch = _fixture.Create<string>();
            var mockedLog = _fixture.Create<List<string>>();

            //Act
            var exception = await Record.ExceptionAsync(async () => await _logConverterBusiness.MakeNewFile(mockedLog, filePatch));

            //Assert
            await _outputAddapter.Received(0).SaveFile(Arg.Any<List<string>>(), Arg.Any<string>());
            exception.Should().BeOfType<IndexOutOfRangeException>();
        }

        private List<string> GetMockedLog()
        {
            var logs = new List<string>();
            logs.Add("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2");
            logs.Add("101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4");
            logs.Add("199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9");
            logs.Add("312|200|INVALIDATE|\"GET /robots.txt HTTP/1.1\"|245.1");

            return logs;
        }
    }
}
