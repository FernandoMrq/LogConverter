using AutoFixture;
using CandidateTesting.FernandoMarques.Core.Application;
using CandidateTesting.FernandoMarques.Core.Domain.Business;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace CandidateTesting.FernandoMarques.Test.Core.Application
{
    public class LogConverterApplicationTest
    {
        private readonly Fixture _fixture;
        private readonly ILogConverterBusiness _logConverterBusiness;
        private readonly ILogConverterApplication _logConverterApplication;

        public LogConverterApplicationTest()
        {
            _logConverterBusiness = Substitute.For<ILogConverterBusiness>();
            _fixture = new Fixture();
            _logConverterApplication = new LogConverterApplication(_logConverterBusiness);
        }

        [Fact]
        public async void StartConverterLog_ShouldReturnEmpty_WhenArgsIsEmpty()
        {
            //Arrange
            string[] args = { };

            //Act
            _logConverterApplication.StartConverterLog(args);

            //Assert
            await _logConverterBusiness.Received(0).MakeNewFile(Arg.Any<List<string>>(), Arg.Any<string>());
        }

        [Fact]
        public async void StartConverterLog_ShouldReturnEmpty_WhenUrlIsNotValid()
        {
            //Arrange
            string[] args = { _fixture.Create<string>(), _fixture.Create<string>() };

            //Act
            _logConverterApplication.StartConverterLog(args);

            //Assert
            await _logConverterBusiness.Received(0).MakeNewFile(Arg.Any<List<string>>(), Arg.Any<string>());
        }

        [Fact]
        public async void StartConverterLog_ShouldReturnEmpty_WhenUrlIsValid()
        {
            //Arrange
            string[] args = { "https://www.google.com.br/", _fixture.Create<string>() };
            var logs = new List<string>();

            _logConverterBusiness.DownloadLog(Arg.Any<string>()).Returns(logs);

            //Act
            _logConverterApplication.StartConverterLog(args);

            //Assert
            await _logConverterBusiness.Received(1).MakeNewFile(Arg.Any<List<string>>(), Arg.Any<string>());
        }

    }
}
