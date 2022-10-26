namespace RabbitMqConsumerTemplate.Infrastructure.Versioning;

using Microsoft.AspNetCore.Mvc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        return services.AddApiVersioning(options =>
                                             {
                                                 options.DefaultApiVersion = ApiVersion.Default;
                                                 options.AssumeDefaultVersionWhenUnspecified = true;
                                                 options.ReportApiVersions = true;
                                             })
                       .AddVersionedApiExplorer(options =>
                                                    {
                                                        options.GroupNameFormat = "'v'VVV";
                                                        options.SubstituteApiVersionInUrl = true;
                                                    });
    }
}