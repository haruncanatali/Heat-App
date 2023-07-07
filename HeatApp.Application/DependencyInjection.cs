using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HeatApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}