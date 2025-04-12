using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Delete
{
    public sealed class DeleteAllergyCommandValidator : AbstractValidator<DeleteAllergyCommand>
    {
        public DeleteAllergyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}