using HeatApp.Application.Common.Interfaces;
using HeatApp.Domain.Entities;
using MediatR;

namespace HeatApp.Application.Heats.Commands.CreateHeat;

public class CreateHeatCommand : IRequest<Unit>
{
    public string DeviceId { get; set; }
    public double HeatValue { get; set; }

    public class Handler : IRequestHandler<CreateHeatCommand, Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateHeatCommand request, CancellationToken cancellationToken)
        {
            await _context.Heats.AddAsync(new Heat
            {
                DeviceId = request.DeviceId,
                HeatValue = request.HeatValue
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}