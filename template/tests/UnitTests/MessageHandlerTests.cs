namespace RabbitMqConsumerTemplate.UnitTests;

using Xunit;
using Contracts;

public class MessageHandlerTests
{
    private readonly MessageHandler _sut;

    public MessageHandlerTests()
    {
        _sut = new MessageHandler();
    }

    [Fact]
    public void OnMessageReceived_ReturnsAck()
    {
        // Arrange
        var message = new MessageContract();

        // Assert
        Assert.ThrowsAsync<NotImplementedException>(async () => await _sut.OnMessageReceived(message, default));
    }
}