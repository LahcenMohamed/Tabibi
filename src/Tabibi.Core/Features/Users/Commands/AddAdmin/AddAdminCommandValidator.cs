using FluentValidation;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Users.Commands.AddAdmin
{
    public sealed class AddAdminCommandValidator : AbstractValidator<AddAdminCommand>
    {
        private readonly IUserServices _userServices;

        public AddAdminCommandValidator(IUserServices userServices)
        {
            _userServices = userServices;
            ApplyRule();
            ApplyCustomRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().MinimumLength(8);
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.UserName).Must((key, cancellationToken) => !_userServices.IsUserNameExist(key.UserName))
                .WithMessage("this username is already used");
        }
    }
}
