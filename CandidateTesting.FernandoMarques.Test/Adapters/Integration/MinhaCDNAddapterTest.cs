using AutoFixture;
using CandidateTesting.FernandoMarques.Adapters.Integration;
using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using CandidateTesting.FernandoMarques.Infra;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using Xunit;

namespace CandidateTesting.FernandoMarques.Test.Adapters.Integration
{
    public class MinhaCDNAddapterTest
    {
        private readonly IInputAddapter _inputAddapter;
        private readonly IWebClient _webClient;
        private readonly Fixture _fixture;
        public MinhaCDNAddapterTest()
        {
            _fixture = new Fixture();
            _webClient = Substitute.For<IWebClient>();
            _inputAddapter = new MinhaCDNAddapter(_webClient);
        }

        [Fact]
        public async void GetLogList_ShouldReturnLogList_WhenAllIsOk()
        {
            //Arrange
            var url = _fixture.Create<string>();
            var bytes = _fixture.Create<byte[]>();
            _webClient.DownloadData(Arg.Any<string>()).Returns(bytes);

            //Act
            var logs = await _inputAddapter.GetLogList(url);

            //Assert
            logs.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async void GetLogList_ShouldReturnDefault_WhenThrowsInternalException()
        {
            //Arrange
            var url = _fixture.Create<string>();
            var bytes = _fixture.Create<byte[]>();
            _webClient.DownloadData(Arg.Any<string>()).Throws(new Exception());

            //Act
            var logs = await _inputAddapter.GetLogList(url);

            //Assert
            logs.Should().BeNull();
        }
    }
}
