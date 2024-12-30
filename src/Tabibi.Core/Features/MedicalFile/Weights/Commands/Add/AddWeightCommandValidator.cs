using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Add
{
    public sealed class AddWeightCommandValidator : AbstractValidator<AddWeightCommand>
    {
        public AddWeightCommandValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(1000);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}