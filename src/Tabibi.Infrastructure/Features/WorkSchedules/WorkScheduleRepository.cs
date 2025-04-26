using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.WorkSchedules;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.WorkSchedules
{
    public class WorkScheduleRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<WorkSchedule>(context, configuration),IWorkScheduleRepository
    {
        
    }
}