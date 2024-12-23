using FluentValidation;

namespace Tabibi.Core.Features.Employees.Commands.Add
{
    public sealed class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(x => x.FullName.FirstName).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.FullName.MiddelName).MaximumLength(100);
            RuleFor(x => x.FullName.LastName).NotNull().NotEmpty().MaximumLength(100);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Address).MaximumLength(100);
            RuleFor(x => x.Salary).GreaterThanOrEqualTo(0m);
        }
    }
}
