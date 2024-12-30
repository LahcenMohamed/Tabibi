using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Add
{
    public sealed class AddBloodPressureCommandValidator : AbstractValidator<AddBloodPressureCommand>
    {
        public AddBloodPressureCommandValidator()
        {
            RuleFor(x => x.MinValue).GreaterThan(20).LessThan(300);
            RuleFor(x => x.MinValue).GreaterThan(40).LessThan(400);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
