using Grpc.Core;
using HeatApp.Application.Heats.Commands.CreateHeatWithQueue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeatApp.GrpcService.Services;

public class HeatService : TemperatureReceiver.TemperatureReceiverBase
{
    private readonly IMediator _mediator;

    public HeatService(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async override Task<TemperatureReply> SendTemperature(TemperatureRequest request, ServerCallContext context)
    {
        var result = await _mediator.Send(new CreateHeatWithQueueCommand
        {
            DeviceId = request.Device,
            HeatValue = request.Temperature
        });

        return new TemperatureReply
        {
            Result = true
        };
    }
}