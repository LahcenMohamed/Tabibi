using FluentValidation;

namespace Tabibi.Core.Features.WorkSchedules.Commands.Update;

public sealed class UpdateWorkScheduleCommandValidator : AbstractValidator<UpdateWorkScheduleCommand>
{
    public UpdateWorkScheduleCommandValidator()
    {
        RuleFor(x => x.MaxAppointmentsCount).GreaterThan(0);
    }
}
