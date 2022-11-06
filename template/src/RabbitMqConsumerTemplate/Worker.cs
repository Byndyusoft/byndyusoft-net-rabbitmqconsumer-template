namespace RabbitMqConsumerTemplate;

using Byndyusoft.Messaging.RabbitMq;
using Contracts;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMessageHandler _messageHandler;
    private readonly IRabbitMqClient _rabbitMqClient;

    public Worker(ILogger<Worker> logger, IRabbitMqClient rabbitMqClient, IMessageHandler messageHandler)
    {
        _logger = logger;
        _rabbitMqClient = rabbitMqClient;
        _messageHandler = messageHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var exchangeName = "exchangeName";
        var queueName = "queueName";
        var routingKey = "routingKey";
        var retryPeriod = TimeSpan.FromSeconds(1);
        ushort prefetchCount = 20;
        int? maxRetryCount = 10; // infinite retry when null

        // worker consumes messages sent by PublishAsJsonAsync method:
        //var message = new MessageContract { Property = "example message" };
        //await _rabbitMqClient.PublishAsJsonAsync(exchangeName, routingKey, message, cancellationToken: stoppingToken);

        // remove unnecessary steps if it's done in other place (exchange creation, queue declaration and binding)
        await _rabbitMqClient.CreateExchangeIfNotExistsAsync(exchangeName,
                                                             options => options.AsDurable(true).AsAutoDelete(false),
                                                             stoppingToken);
        using var consumer =
            _rabbitMqClient
                .SubscribeAsJson<MessageContract>(queueName, _messageHandler.OnMessageReceived)
                // we can get message as JsonElement if we don't know type beforehand:
                //.SubscribeAsJson<JsonElement>(queueName, OnMessageJsonElement) 
                .WithDeclareSubscribingQueue(options => options.AsDurable(true).AsAutoDelete(false))
                .WithSubscribingQueueBinding(exchangeName, routingKey)
                .WithPrefetchCount(prefetchCount)
                .WithDeclareErrorQueue(options => options.AsDurable(true).AsAutoDelete(false))
                .WithConstantTimeoutRetryStrategy(retryPeriod,
                                                  maxRetryCount,
                                                  options => options.AsDurable(true).AsAutoDelete(false))
                .Start();

        _logger.LogInformation(
                               "Consumer for queue : {queueName} with prefetch count : {prefetchCount}, retry period : {retryPeriod} and max retry count : {maxRetryCount} started",
                               prefetchCount,
                               queueName,
                               retryPeriod,
                               maxRetryCount);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}