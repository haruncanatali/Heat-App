using FluentValidation;

namespace HeatApp.Application.Heats.Commands.CreateHeat;

public class CreateHeatCommandValidator : AbstractValidator<CreateHeatCommand>
{
    public CreateHeatCommandValidator()
    {
        RuleFor(c => c.DeviceId).NotEmpty()
            .WithMessage("Cihaz tanımlayıcısı boş olmamalıdır.");
        RuleFor(c => c.HeatValue).NotNull()
            .WithMessage("Sıcaklık değeri boş olmamalıdır.");
    }
}