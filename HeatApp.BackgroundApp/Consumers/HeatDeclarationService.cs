using HeatApp.Application.Common.Models.Heat;
using HeatApp.Application.Heats.Commands.CreateHeat;
using HeatApp.BackgroundApp.Services;
using MediatR;

namespace HeatApp.BackgroundApp.Consumers;

public class HeatDeclarationService : IHeatDeclarationService
{
    private readonly IMediator _mediator;

    public HeatDeclarationService(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task AddHeatValue(AddHeatRequestModel model)
    {
        await _mediator.Send(new CreateHeatCommand
        {
            DeviceId = model.DeviceId,
            HeatValue = model.HeatValue
        });
    }
}