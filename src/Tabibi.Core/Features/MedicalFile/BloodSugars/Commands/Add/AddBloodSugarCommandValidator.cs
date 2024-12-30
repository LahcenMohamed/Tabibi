using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Add
{
    public sealed class AddBloodSugarCommandValidator : AbstractValidator<AddBloodSugarCommand>
    {
        public AddBloodSugarCommandValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(1000);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}