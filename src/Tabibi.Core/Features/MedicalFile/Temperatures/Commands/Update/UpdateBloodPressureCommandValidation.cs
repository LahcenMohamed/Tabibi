using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Temperatures.Commands.Update
{
    public sealed class UpdateTemperatureCommandValidation : AbstractValidator<UpdateTemperatureCommand>
    {
        public UpdateTemperatureCommandValidation()
        {
            RuleFor(x => x.Value).GreaterThan(20).LessThan(50);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
