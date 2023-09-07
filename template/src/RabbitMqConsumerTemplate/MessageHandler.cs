namespace RabbitMqConsumerTemplate;

using System.Diagnostics;
using Byndyusoft.Messaging.RabbitMq;
using Contracts;
using Infrastructure.OpenTelemetry;

public class MessageHandler : IMessageHandler
{
    public async Task<ConsumeResult> OnMessageReceived(MessageContract? message, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        //TODO: implement message processing here
        throw new NotImplementedException();
        
        stopwatch.Stop();
        ConsumerTemplateMetrics.ObserveDuration(message!.Property, stopwatch.Elapsed);
        
        return ConsumeResult.Ack;
    }
}