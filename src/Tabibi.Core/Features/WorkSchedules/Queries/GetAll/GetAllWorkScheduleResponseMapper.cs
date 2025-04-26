using Riok.Mapperly.Abstractions;
using Tabibi.Domain.WorkSchedules;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

[Mapper]
public static partial class GetAllWorkScheduleResponseMapper
{
    public static partial IQueryable<GetAllWorkScheduleResponse> ToDto(this IQueryable<WorkSchedule> workSchedules);
}
