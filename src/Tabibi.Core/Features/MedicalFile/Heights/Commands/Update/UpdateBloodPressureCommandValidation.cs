using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Update
{
    public sealed class UpdateHeightCommandValidation : AbstractValidator<UpdateHeightCommand>
    {
        public UpdateHeightCommandValidation()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(300);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}
