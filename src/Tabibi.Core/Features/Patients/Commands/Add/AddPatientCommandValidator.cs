using FluentValidation;

namespace Tabibi.Core.Features.Patients.Commands.Add
{
    public sealed class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
    {
        public AddPatientCommandValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Matches("[0-9]").MaximumLength(20);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(200);
        }
    }
}
