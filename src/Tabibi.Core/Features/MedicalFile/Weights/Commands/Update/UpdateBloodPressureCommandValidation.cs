using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Update
{
    public sealed class UpdateWeightCommandValidation : AbstractValidator<UpdateWeightCommand>
    {
        public UpdateWeightCommandValidation()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(1000);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
