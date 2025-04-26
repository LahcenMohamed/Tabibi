using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Appointments
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        
    }
}