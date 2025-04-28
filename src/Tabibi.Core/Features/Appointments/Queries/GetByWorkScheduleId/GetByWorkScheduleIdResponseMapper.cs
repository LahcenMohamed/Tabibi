using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riok.Mapperly.Abstractions;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;

namespace Tabibi.Core.Features.Appointments.Queries.GetByWorkScheduleId
{
    [Mapper]
    public static partial class GetByWorkScheduleIdResponseMapper
    {
        public static partial IQueryable<GetByWorkScheduleIdResponse> ToDto(this IQueryable<Appointment> appointments);
    }
}