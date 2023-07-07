using HeatApp.Application.Common.Helpers.Queue;
using HeatApp.Application.Common.Models.Heat;
using MediatR;

namespace HeatApp.Application.Heats.Commands.CreateHeatWithQueue;

public class CreateHeatWithQueueCommand : IRequest<Unit>
{
    public double HeatValue { get; set; }
    public string DeviceId { get; set; }
    
    public class Handler : IRequestHandler<CreateHeatWithQueueCommand,Unit>
    {
        private readonly QueueHelper _queueHelper;

        public Handler(QueueHelper queueHelper)
        {
            _queueHelper = queueHelper;
        }

        public async Task<Unit> Handle(CreateHeatWithQueueCommand request, CancellationToken cancellationToken)
        {
            _queueHelper.Send(new AddHeatRequestModel
            {
                DeviceId = request.DeviceId,
                HeatValue = request.HeatValue
            });

            return Unit.Value;
        }
    }
}