using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;
using Tabibi.Infrastructure.DbContexts;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Appointments
{
    public sealed class AppointmentRepository(TabibiDbContext context, IConfiguration configuration)
        : BaseRepository<Appointment>(context, configuration),IAppointmentRepository
    {
        
    }
}