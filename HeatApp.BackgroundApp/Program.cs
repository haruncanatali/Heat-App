using HeatApp.Application;
using HeatApp.BackgroundApp.Configs;
using HeatApp.BackgroundApp.Consumers;
using HeatApp.BackgroundApp.Managers;
using HeatApp.BackgroundApp.Services;
using HeatApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSettingsConfig(builder.Configuration);
builder.Services.AddLogging();
builder.Services.AddApplication();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRabbitMqQueue(builder.Configuration,builder.Configuration.GetValue<string>("RabbitMQSetting:CloudUri"),builder.Configuration.GetValue<string>("RabbitMQSetting:RoutingKey"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IHeatDeclarationService, HeatDeclarationService>();
builder.Services.AddTransient<HeatConsumer>();
builder.Services.AddHostedService<HeatHostedService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();