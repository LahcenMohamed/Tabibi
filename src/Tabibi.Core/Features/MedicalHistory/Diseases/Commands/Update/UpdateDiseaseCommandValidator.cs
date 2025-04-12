using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Update
{
    public sealed class UpdateDiseaseCommandValidator : AbstractValidator<UpdateDiseaseCommand>
    {
        public UpdateDiseaseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("End date must be greater than or equal to start date");
        }
    }
}