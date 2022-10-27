namespace RabbitMqConsumerTemplate;

using System.Text.Json.Serialization;
using Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

        services
            .AddMvcCore()
            .AddTracing();

        services
            .AddRouting(options => options.LowercaseUrls = true)
            .AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddHealthChecks();

        services.AddApplicationServices();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseHealthChecks("/healthz")
           .UseMetricServer();
    }
}