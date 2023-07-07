using System.Globalization;
using FluentValidation;
using HeatApp.Application.Common.Helpers.Queue;
using HeatApp.Application.Common.Models;

namespace HeatApp.GrpcService.Configs;

public static class SettingsConfig
{
    public static IServiceCollection AddSettingsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var cultureInfo = new CultureInfo("tr-TR");
        System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
        ValidatorOptions.Global.LanguageManager.Culture = cultureInfo;
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        services.Configure<RabbitMQSetting>(configuration.GetSection("RabbitMQSetting"));
        services.AddTransient<QueueHelper>();
        return services;
    }
}