using FluentValidation;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Add;

public sealed class AddWorkScheduleCommandValidator : AbstractValidator<AddWorkScheduleCommand>
{
    public AddWorkScheduleCommandValidator()
    {
        RuleFor(x => x.MaxAppointmentsCount).GreaterThan(0);
    }
}
