using Tabibi.Domain.WorkSchedules;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetByClinic;

public sealed record GetWorkSchedulesByClinicResponse(
    Guid Id,
    DateOnly Date,
    int MaxAppointmentsCount);

public static class GetWorkSchedulesByClinicResponseMapper
{
    public static GetWorkSchedulesByClinicResponse ToResponse(WorkSchedule workSchedule)
    {
        return new GetWorkSchedulesByClinicResponse(
            workSchedule.Id,
            workSchedule.Date,
            workSchedule.MaxAppointmentsCount);
    }

    public static List<GetWorkSchedulesByClinicResponse> ToResponse(List<WorkSchedule> workSchedules)
    {
        return workSchedules.Select(ToResponse).ToList();
    }
}