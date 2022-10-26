namespace UnitTests;

using Byndyusoft.Messaging.RabbitMq;
using Contracts;
using RabbitMqConsumerTemplate;

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
    public async Task OnMessageReceived_ReturnsAck()
    {
        // Arrange
        var message = new MessageContract();

        // Act
        var result = await _sut.OnMessageReceived(message, default);

        // Assert
        Assert.That(result, Is.TypeOf<AckConsumeResult>());
    }
}