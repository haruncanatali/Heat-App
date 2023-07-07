using HeatApp.Application.Heats.Queries.Dtos;

namespace HeatApp.Application.Common.Interfaces;

public interface IHeatHub
{
    Task SendLatestHeatData(HeatDto model);
}