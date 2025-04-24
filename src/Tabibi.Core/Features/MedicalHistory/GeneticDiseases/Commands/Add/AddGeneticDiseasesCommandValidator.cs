using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Add
{
    public sealed class AddGeneticDiseasesCommandValidator : AbstractValidator<AddGeneticDiseasesCommand>
    {
        public AddGeneticDiseasesCommandValidator()
        {
            RuleFor(x => x.DiseaseName).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
