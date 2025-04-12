using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Add
{
    public sealed class AddChronicDiseasesCommandValidator : AbstractValidator<AddChronicDiseasesCommand>
    {
        public AddChronicDiseasesCommandValidator()
        {
            RuleFor(x => x.DiseaseName).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}