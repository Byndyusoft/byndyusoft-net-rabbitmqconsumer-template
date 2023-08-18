namespace RabbitMqConsumerTemplate.UnitTests;

using RabbitMqConsumerTemplate;
using Contracts;

[TestFixture]
public class MessageHandlerTests
{
    [SetUp]
    public void Setup()
    {
        _sut = new MessageHandler();
    }

    private MessageHandler _sut = null!;

    [Test]
    public void OnMessageReceived_ReturnsAck()
    {
        // Arrange
        var message = new MessageContract();

        // Assert
        Assert.ThrowsAsync<NotImplementedException>(async() => await _sut.OnMessageReceived(message, default));
    }
}