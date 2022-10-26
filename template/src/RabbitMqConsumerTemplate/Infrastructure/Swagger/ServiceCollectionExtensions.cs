namespace RabbitMqConsumerTemplate.Infrastructure.Swagger;

using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                    .AddSwaggerGen();
    }
}