namespace RabbitMqConsumerTemplate;

using Byndyusoft.Messaging.RabbitMq;
using Contracts;

public interface IMessageHandler
{
    Task<ConsumeResult> OnMessageReceived(MessageContract? message, CancellationToken cancellationToken);
}