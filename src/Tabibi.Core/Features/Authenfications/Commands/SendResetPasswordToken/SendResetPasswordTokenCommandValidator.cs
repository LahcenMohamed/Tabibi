using FluentValidation;

namespace Tabibi.Core.Features.Authenfications.Commands.SendResetPasswordToken
{
    public sealed class SendResetPasswordTokenCommandValidator : AbstractValidator<SendResetPasswordTokenCommand>
    {
        public SendResetPasswordTokenCommandValidator()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserNameOrEmail).NotNull().NotEmpty().MinimumLength(4);
        }
    }
}
