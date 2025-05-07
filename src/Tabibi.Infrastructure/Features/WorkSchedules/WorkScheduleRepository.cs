using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.WorkSchedules
{
    public class WorkScheduleRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<WorkSchedule>(context, configuration),IWorkScheduleRepository
    {
        public async Task<List<WorkSchedule>> GetByClinicIdAsync(Guid clinicId)
        {
            return await context.Set<WorkSchedule>()
                .Where(w => w.ClinicId == clinicId)
                .ToListAsync();
        }
    }
}