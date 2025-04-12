using FluentValidation;
using Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Update;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Update.Validators
{
    public class UpdateChronicDiseaseCommandValidator : AbstractValidator<UpdateChronicDiseaseCommand>
    {
        public UpdateChronicDiseaseCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Chronic disease ID is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
