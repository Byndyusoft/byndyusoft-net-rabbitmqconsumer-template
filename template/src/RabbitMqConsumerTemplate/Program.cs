namespace RabbitMqConsumerTemplate;

using Byndyusoft.Logging.Configuration;
using Byndyusoft.MaskedSerialization.Serilog.Extensions;
using Infrastructure.OpenTelemetry;
using Microsoft.AspNetCore.Hosting;
using OpenTelemetry.Trace;
using Serilog;

public static class Program
{
    private static readonly string ServiceName = typeof(Program).Assembly.GetName().Name!;

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(ConfigureWebHostDefaultsAction)
                   .ConfigureServices(ConfigureServicesAction)
                   .UseSerilog(ConfigureSerilogAction);
    }

    private static void ConfigureWebHostDefaultsAction(IWebHostBuilder builder)
    {
        builder.UseStartup<Startup>();
    }

    private static void ConfigureServicesAction(HostBuilderContext context, IServiceCollection services)
    {
        services.AddOpenTelemetry(ServiceName,
                                  context.Configuration.GetSection("Jaeger").Bind,
                                  builder => builder.AddRabbitMqClientInstrumentation(),
                                  builder => builder.AddTemplateMetrics());

        services.AddHostedService<Worker>();
    }

    private static void ConfigureSerilogAction(HostBuilderContext context, LoggerConfiguration configuration)
    {
        configuration
            .UseDefaultSettings(context.Configuration, ServiceName)
            .UseOpenTelemetryTraces()
            .WriteToOpenTelemetry()
            .WithMaskingPolicy();
    }
}