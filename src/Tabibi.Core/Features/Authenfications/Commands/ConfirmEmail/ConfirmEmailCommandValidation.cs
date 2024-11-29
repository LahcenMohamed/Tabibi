using FluentValidation;

namespace Tabibi.Core.Features.Authenfications.Commands.ConfirmEmail
{
    public sealed class ConfirmEmailCommandValidation : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidation()
        {
            ApplyRule();
        }

        private void ApplyRule()
        {
            RuleFor(x => x.UserNameOrEmail).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(x => x.Code).NotNull().NotEmpty().Length(6);
        }
    }
}
