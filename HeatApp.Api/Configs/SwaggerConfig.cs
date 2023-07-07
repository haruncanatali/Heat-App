using Microsoft.OpenApi.Models;

namespace HeatApp.Api.Configs;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hero.Api", Version = "v1" });
        });
        return services;
    }
}