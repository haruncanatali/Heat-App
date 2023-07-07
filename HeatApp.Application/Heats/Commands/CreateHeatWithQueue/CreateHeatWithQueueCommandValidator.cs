using FluentValidation;

namespace HeatApp.Application.Heats.Commands.CreateHeatWithQueue;

public class CreateHeatWithQueueCommandValidator : AbstractValidator<CreateHeatWithQueueCommand>
{
    public CreateHeatWithQueueCommandValidator()
    {
        RuleFor(c => c.DeviceId).NotEmpty()
            .WithMessage("Cihaz tanımlayıcısı boş olmamalıdır.");
        RuleFor(c => c.HeatValue).NotNull()
            .WithMessage("Sıcaklık değeri boş olmamalıdır.");
    }
}