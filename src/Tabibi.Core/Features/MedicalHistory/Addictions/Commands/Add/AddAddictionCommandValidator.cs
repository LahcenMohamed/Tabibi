using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Add
{
    public sealed class AddAddictionCommandValidator : AbstractValidator<AddAddictionCommand>
    {
        public AddAddictionCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
