using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeatApp.Application.Common.Interfaces;
using HeatApp.Application.Heats.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HeatApp.Application.Heats.Queries.GetLastHeat;

public class GetLastHeatQueryHandler : IRequestHandler<GetLastHeatQuery,HeatDto>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetLastHeatQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<HeatDto> Handle(GetLastHeatQuery request, CancellationToken cancellationToken)
    {
        HeatDto? result = await _context.Heats
            .OrderByDescending(c => c.CreatedAt)
            .ProjectTo<HeatDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}