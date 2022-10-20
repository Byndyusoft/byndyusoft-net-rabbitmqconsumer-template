namespace RabbitMqConsumerTemplate;

internal static class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
                       .ConfigureServices(ConfigureAction)
                       .Build();

        host.Run();
    }

    private static void ConfigureAction(HostBuilderContext context, IServiceCollection services)
    {
        var rabbitConnectionString = context.Configuration.GetConnectionString("Rabbit");
        services.AddRabbitMqClient(options => { options.ConnectionString = rabbitConnectionString; });
        services.AddSingleton<IMessageHandler, MessageHandler>();
        services.AddHostedService<Worker>();
    }
}