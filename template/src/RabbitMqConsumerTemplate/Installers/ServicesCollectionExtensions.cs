namespace RabbitMqConsumerTemplate.Installers;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IMessageHandler, MessageHandler>();

        return services;
    }
}