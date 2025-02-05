using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Update
{
    public sealed class UpdateBloodPressureCommandValidation : AbstractValidator<UpdateBloodPressureCommand>
    {
        public UpdateBloodPressureCommandValidation()
        {
            RuleFor(x => x.MinValue).GreaterThan(20).LessThan(300);
            RuleFor(x => x.MinValue).GreaterThan(40).LessThan(400);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
