namespace RabbitMqConsumerTemplate;

using Byndyusoft.Messaging.RabbitMq;
using Contracts;

public interface IMessageHandler
{
    Task<ConsumeResult> OnMessageReceivedHandler(MessageContract? message, CancellationToken cancellationToken);
}