using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Add
{
    public sealed class AddAllergyCommandValidator : AbstractValidator<AddAllergyCommand>
    {
        public AddAllergyCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
