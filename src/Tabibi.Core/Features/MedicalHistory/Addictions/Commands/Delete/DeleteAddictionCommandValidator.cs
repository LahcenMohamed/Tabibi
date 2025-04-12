using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Delete
{
    public sealed class DeleteAddictionCommandValidator : AbstractValidator<DeleteAddictionCommand>
    {
        public DeleteAddictionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Addiction Id is required");
        }
    }
}