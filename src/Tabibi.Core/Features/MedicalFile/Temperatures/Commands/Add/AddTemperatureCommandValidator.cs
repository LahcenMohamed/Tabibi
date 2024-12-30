using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Add
{
    public sealed class AddTemperatureCommandValidator : AbstractValidator<AddTemperatureCommand>
    {
        public AddTemperatureCommandValidator()
        {
            RuleFor(x => x.Value).GreaterThan(20).LessThan(50);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}