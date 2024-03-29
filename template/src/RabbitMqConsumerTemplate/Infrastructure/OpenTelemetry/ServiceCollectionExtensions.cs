namespace RabbitMqConsumerTemplate.Infrastructure.OpenTelemetry;

using global::OpenTelemetry.Exporter;
using global::OpenTelemetry.Metrics;
using global::OpenTelemetry.Resources;
using global::OpenTelemetry.Trace;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenTelemetry(
        this IServiceCollection services,
        string serviceName,
        Action<OtlpExporterOptions> configureOtlp,
        Action<TracerProviderBuilder>? configureBuilder = null,
        Action<MeterProviderBuilder>? configureMeter = null)
    {
        services
            .AddOpenTelemetry()
            .WithTracing
                (builder =>
                     {
                         builder
                             .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                             .AddDefaultIgnorePatterns()
                             .AddOtlpExporter(configureOtlp);
                         configureBuilder?.Invoke(builder);
                     })
            .WithMetrics(builder =>
                             {
                                 builder.AddPrometheusExporter()
                                        .AddRuntimeInstrumentation();
                                 configureMeter?.Invoke(builder);
                             });

        return services;
    }
}