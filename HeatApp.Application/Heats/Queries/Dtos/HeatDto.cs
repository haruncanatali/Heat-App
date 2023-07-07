using AutoMapper;
using HeatApp.Application.Common.Mappings;
using HeatApp.Domain.Entities;

namespace HeatApp.Application.Heats.Queries.Dtos;

public class HeatDto : IMapFrom<Heat>
{
    public long Id { get; set; }
    public double HeatValue { get; set; }
    public string Color { get; set; }
    public string CreatedAt { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Heat, HeatDto>()
            .ForMember(dest => dest.Color,opt => 
                opt.MapFrom(c=>SetColor(c.HeatValue)))
            .ForMember(dest => dest.CreatedAt,opt =>
                opt.MapFrom(c=>c.CreatedAt.ToString("dd-MM-yyyy HH:mm:ss")));
    }

    public static string SetColor(double value)
    {
        if (value < 18)
        {
            return "blue";
        }
        else if (value > 18 && value < 28)
        {
            return "green";
        }

        return "red";
    }
}