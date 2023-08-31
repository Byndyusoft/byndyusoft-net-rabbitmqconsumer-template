namespace Byndyusoft.Template.IntegrationTests
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNet.Testing.Infrastructure.ReadmeGeneration.Entities;
    using DotNet.Testing.Infrastructure.ReadmeGeneration.Services;
    using FluentAssertions;
    using RabbitMqConsumerTemplate;
    using RabbitMqConsumerTemplate.Contracts;
    using TestCases;
    using Xunit;

    public class MessageHandlerTests
    {
        private readonly MessageHandler _sut;

        public MessageHandlerTests()
        {
            _sut = new MessageHandler();
        }
        
        [Fact]
        public async Task OnMessageReceived_ReturnsThrow()
        {
            // Arrange
            var tesCase = new TestCaseItem
                              {
                                  TestId = "MessageHandler",
                                  Description = "MessageHandler",
                                  TestCaseFolder = "MessageHandler",
                                  Parameters = new TestCaseParameters
                                                   {
                                                       Message = new MessageContract()
                                                   },
                                  Mocks = new TestCaseMocks(),
                                  Expected = new TestCaseExpectations()
                              };

            // Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _sut.OnMessageReceived(tesCase.Parameters.Message, default));
        }
        
        [Fact]
        public async Task AddReport_FromCurrentDomain_ShouldAddReadmeInSolutionRoot()
        {
            // Arrange
            var reporter = TestCaseReadmeSolutionReporter.New();

            // Act
            var reportConsistency = await reporter.AddReport(Assembly.GetExecutingAssembly());

            // Assert
            reportConsistency.Should().Be(ReportConsistency.Consistent);
        }
    }
}