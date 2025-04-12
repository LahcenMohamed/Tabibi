using FluentValidation;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Update
{
    public sealed class UpdateAddictionCommandValidator : AbstractValidator<UpdateAddictionCommand>
    {
        public UpdateAddictionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Addiction Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
        }
    }
}