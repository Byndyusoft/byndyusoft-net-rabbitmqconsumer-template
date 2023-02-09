namespace RabbitMqConsumerTemplate;

using Installers;
using Microsoft.AspNetCore.Builder;
using Prometheus;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var rabbitConnectionString = _configuration.GetConnectionString("Rabbit");
        services.AddRabbitMqClient(options => { options.ConnectionString = rabbitConnectionString; });

        services.AddHealthChecks();

        services.AddApplicationServices();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseHealthChecks("/healthz")
           .UseMetricServer();
    }
}