using FluentValidation;

namespace Tabibi.Core.Features.Authenfications.Commands.ResetPassword
{
    public sealed class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserNameOrEmail).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.NewPassword).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
