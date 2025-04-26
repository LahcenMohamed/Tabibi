using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabibi.Domain.Shared.AggregateRoots;

namespace Tabibi.Domain.WorkSchedules
{
    public sealed class WorkSchedule : FullAuditedAggregateRoot
    {
        public DateOnly Date { get; private set; }
        public int MaxAppointmentsCount { get; private set; }
        public Guid ClinicId { get; private set; }

        private WorkSchedule() { }

        public static WorkSchedule Create(
            DateOnly date, 
            int maxAppointmentsCount, 
            Guid clinicId,
            Guid userId)
        {
            return new WorkSchedule
            {
                Date = date,
                MaxAppointmentsCount = maxAppointmentsCount,
                ClinicId = clinicId,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(DateOnly date, int maxAppointmentsCount, Guid userId)
        {
            Date = date;
            MaxAppointmentsCount = maxAppointmentsCount;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }
    }

}