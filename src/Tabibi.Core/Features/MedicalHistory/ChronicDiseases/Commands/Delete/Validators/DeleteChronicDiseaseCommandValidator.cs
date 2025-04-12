using FluentValidation;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Delete;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Delete.Validators
{
    public class DeleteChronicDiseaseCommandValidator : AbstractValidator<DeleteChronicDiseaseCommand>
    {
        public DeleteChronicDiseaseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Chronic disease ID is required");
        }
    }
}