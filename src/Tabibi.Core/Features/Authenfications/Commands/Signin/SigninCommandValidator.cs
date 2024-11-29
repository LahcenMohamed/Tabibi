using FluentValidation;

namespace Tabibi.Core.Features.Authenfications.Commands.Signin
{
    public sealed class SigninCommandValidator : AbstractValidator<SigninCommand>
    {
        public SigninCommandValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.EmailOrUserName).NotNull().NotEmpty().MinimumLength(4).MaximumLength(35);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(4).MaximumLength(35);
        }
    }
}
