namespace Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

public sealed  class GetAllWorkScheduleResponse
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public int MaxAppointmentsCount { get; set; }
}
