using Byndyusoft.Logging.Configuration;
using Byndyusoft.MaskedSerialization.Serilog.Extensions;
using OpenTelemetry.Trace;
using RabbitMqConsumerTemplate;
using RabbitMqConsumerTemplate.Infrastructure.OpenTelemetry;
using RabbitMqConsumerTemplate.Installers;
using Serilog;

var serviceName = typeof(Program).Assembly.GetName().Name!;
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var rabbitConnectionString = builder.Configuration.GetConnectionString("Rabbit");

builder.Host.UseSerilog(ConfigureSerilogAction);
services.AddOpenTelemetry(
    serviceName,
    builder.Configuration.GetSection("OtlpExporterOptions").Bind,
    _builder => _builder.AddRabbitMqClientInstrumentation(),
    _builder => _builder.AddTemplateMetrics()
);
services.AddHostedService<Worker>();
services.AddRabbitMqClient(options => { options.ConnectionString = rabbitConnectionString; });
services.AddHealthChecks();
services.AddApplicationServices();

var app = builder.Build();
app.UseHealthChecks("/healthz")
   .UseOpenTelemetryPrometheusScrapingEndpoint();
app.Run();

static void ConfigureSerilogAction(HostBuilderContext context, LoggerConfiguration configuration)
{
    configuration
        .UseDefaultSettings(context.Configuration)
        .UseOpenTelemetryTraces()
        .WriteToOpenTelemetry()
        .WithMaskingPolicy();
}