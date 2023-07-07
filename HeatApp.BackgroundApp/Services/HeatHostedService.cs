using System.Text;
using System.Text.Json;
using HeatApp.Application.Common.Models;
using HeatApp.Application.Common.Models.Heat;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HeatApp.BackgroundApp.Services;

public class HeatConsumer
{
    private readonly RabbitMQSetting _rabbitMqSetting;
    private readonly IServiceScopeFactory _scopeFactory;
    private IConnection _connection;
    private readonly JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    
    public HeatConsumer(IOptions<RabbitMQSetting> rabbitMqSettings, IServiceScopeFactory scopeFactory)
    {
        _rabbitMqSetting = rabbitMqSettings.Value;
        _scopeFactory = scopeFactory;

        var factory = new ConnectionFactory();
        factory.Uri = new Uri(_rabbitMqSetting.CloudUri);
        
        _connection = factory.CreateConnection();
    }
    
    public Task ExecuteAsync()
    {
        var channel = _connection.CreateModel();
        channel.BasicQos(0, 1, false);

        var heatRequestConsumer = new EventingBasicConsumer(channel);
        HeatRequestConsumer(heatRequestConsumer, channel);
        
        return Task.CompletedTask;
    }
    
    private void HeatRequestConsumer(EventingBasicConsumer heatConsumer, IModel channel)
    {
        heatConsumer.Received += async (ch, ea) =>
        {
            using var scope = _scopeFactory.CreateScope();
            var _declarationService = scope.ServiceProvider.GetService<IHeatDeclarationService>();
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            AddHeatRequestModel model =
                JsonSerializer.Deserialize<AddHeatRequestModel>(content, options);
            await _declarationService.AddHeatValue(model);
            channel.BasicAck(ea.DeliveryTag, false);
        };

        channel.BasicConsume(queue: _rabbitMqSetting.RoutingKey, false, heatConsumer);
    }
}

public class HeatHostedService : BackgroundService, IDisposable
{
    private readonly IServiceScopeFactory _scopeFactory;

    public HeatHostedService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using var scope = _scopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetService<HeatConsumer>();

        await service.ExecuteAsync();
    }
}