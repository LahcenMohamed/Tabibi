using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Add
{
    public sealed class AddDiseaseCommandValidator : AbstractValidator<AddDiseaseCommand>
    {
        public AddDiseaseCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(x => x.PatientId).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than or equal to start date");
        }
    }
}