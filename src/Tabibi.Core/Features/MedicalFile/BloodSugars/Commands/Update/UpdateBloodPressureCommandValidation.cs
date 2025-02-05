using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Update
{
    public sealed class UpdateBloodSugarCommandValidation : AbstractValidator<UpdateBloodSugarCommand>
    {
        public UpdateBloodSugarCommandValidation()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(1000);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
