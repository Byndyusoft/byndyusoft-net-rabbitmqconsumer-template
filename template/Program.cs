namespace RabbitMqConsumerTemplate;

internal class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddRabbitMqClient("host=localhost;username=guest;password=guest");
            })
            .Build();

        host.Run();
    }
}