using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.WorkSchedules
{
    public interface IWorkScheduleRepository : IBaseRepository<WorkSchedule>
    {
        Task<List<WorkSchedule>> GetByClinicIdAsync(Guid clinicId);
    }
}