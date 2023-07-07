using HeatApp.Application.Heats.Commands.CreateHeat;
using HeatApp.Application.Heats.Queries.Dtos;
using HeatApp.Application.Heats.Queries.GetLastHeat;
using Microsoft.AspNetCore.Mvc;

namespace HeatApp.Api.Controllers;

public class HeatController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateHeatCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    public async Task<ActionResult<HeatDto>> GetLastData()
    {
        return Ok(await Mediator.Send(new GetLastHeatQuery()));
    }
}