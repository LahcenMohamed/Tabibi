using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Update
{
    public sealed class UpdateAllergyCommandValidator : AbstractValidator<UpdateAllergyCommand>
    {
        public UpdateAllergyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}