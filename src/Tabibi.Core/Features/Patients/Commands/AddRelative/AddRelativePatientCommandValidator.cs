using FluentValidation;

namespace Tabibi.Core.Features.Patients.Commands.AddRelative
{
    public sealed class AddRelativePatientCommandValidator : AbstractValidator<AddRelativePatientCommand>
    {
        public AddRelativePatientCommandValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).Matches("[0-9]").MaximumLength(20);
            RuleFor(x => x.Email).EmailAddress().MaximumLength(200);
        }
    }
}
