namespace RabbitMqConsumerTemplate;

using Byndyusoft.Messaging.RabbitMq;
using Contracts;

public class MessageHandler : IMessageHandler
{
    public async Task<ConsumeResult> OnMessageReceivedHandler(MessageContract? message, CancellationToken cancellationToken)
    {
        //TODO: implement message processing here

        return ConsumeResult.Ack;
    }
}