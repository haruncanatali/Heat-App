using HeatApp.Application;
using HeatApp.GrpcService.Configs;
using HeatApp.GrpcService.Services;
using HeatApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSettingsConfig(builder.Configuration);
builder.Services.AddLogging();
builder.Services.AddApplication();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapGrpcService<HeatService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();