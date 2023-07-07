using HeatApp.Application.Common.Models.Heat;

namespace HeatApp.BackgroundApp.Services;

public interface IHeatDeclarationService
{
    Task AddHeatValue(AddHeatRequestModel model);
}