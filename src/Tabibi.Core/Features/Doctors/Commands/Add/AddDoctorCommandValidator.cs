using FluentValidation;

namespace Tabibi.Core.Features.Doctors.Commands.Add
{
    public sealed class AddDoctorCommandValidator : AbstractValidator<AddDoctorCommand>
    {
        public AddDoctorCommandValidator()
        {
            RuleFor(x => x.FullName.FirstName).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.FullName.MiddelName).MaximumLength(100);
            RuleFor(x => x.FullName.LastName).NotNull().NotEmpty().MaximumLength(100);

            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Matches("[0-9]").MaximumLength(20);
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.Address.State).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.City).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.Street).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address.UrlOnMap).MaximumLength(150);

            RuleFor(x => x.ClinicPhoneNumber).NotNull().NotEmpty().Matches("[0-9]").MaximumLength(20);
            RuleFor(x => x.SecondPhoneNumber).Matches("[0-9]").MaximumLength(20);

            RuleFor(x => x.ClinicEmail).NotNull().NotEmpty().EmailAddress();

        }
    }
}
