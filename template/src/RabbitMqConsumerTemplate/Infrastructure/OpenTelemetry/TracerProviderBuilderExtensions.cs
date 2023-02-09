namespace RabbitMqConsumerTemplate.Infrastructure.OpenTelemetry;

using global::OpenTelemetry.Trace;

public static class TracerProviderBuilderExtensions
{
    public static TracerProviderBuilder AddDefaultIgnorePatterns(this TracerProviderBuilder builder)
    {
        var ignoredSegments = new[] { "/swagger", "/favicon", "/healthz", "/metrics" };
        return builder
            .AddAspNetCoreInstrumentation
                (aspnet => { aspnet.Filter = context => ignoredSegments.All(s => context.Request.Path.StartsWithSegments(s) == false); });
    }
}