namespace RabbitMqConsumerTemplate.Infrastructure.OpenTelemetry;

using global::OpenTelemetry.Trace;

public static class TracerProviderBuilderExtensions
{
    public static TracerProviderBuilder AddDefaultIgnorePatterns(this TracerProviderBuilder builder)
    {
        var ignoredSegments = new[] { "/swagger", "/favicon", "/healthz", "/metrics" };
        return builder
            .AddHttpClientInstrumentation
                (aspnet => { aspnet.FilterHttpWebRequest = request => ignoredSegments.All(s => PathString.FromUriComponent(request.RequestUri).StartsWithSegments(s) == false); });
    }
}