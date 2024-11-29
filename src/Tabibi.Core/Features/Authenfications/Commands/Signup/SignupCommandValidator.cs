using FluentValidation;
using Tabibi.Infrastructure.Features.Users;

namespace Tabibi.Core.Features.Authenfications.Commands.Signup
{
    public sealed class SignupCommandValidator : AbstractValidator<SignupCommand>
    {
        private readonly IUserServices _userServices;

        public SignupCommandValidator(IUserServices userServices)
        {
            _userServices = userServices;
            AppluRule();
            ApplyCustomRule();
        }

        private void ApplyCustomRule()
        {
            RuleFor(x => x.UserName).Must((key, cancellationToken) => !_userServices.IsUserNameExist(key.UserName));
        }

        private void AppluRule()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MinimumLength(4).MaximumLength(35);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(4).MaximumLength(35);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}
