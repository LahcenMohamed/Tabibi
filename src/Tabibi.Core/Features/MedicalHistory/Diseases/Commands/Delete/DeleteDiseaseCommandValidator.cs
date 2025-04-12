using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Delete
{
    public sealed class DeleteDiseaseCommandValidator : AbstractValidator<DeleteDiseaseCommand>
    {
        public DeleteDiseaseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}