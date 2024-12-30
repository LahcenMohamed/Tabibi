using FluentValidation;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Add
{
    public sealed class AddHeightCommandValidator : AbstractValidator<AddHeightCommand>
    {
        public AddHeightCommandValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).LessThan(300);
            RuleFor(x => x.Notes).MaximumLength(250);
        }
    }
}