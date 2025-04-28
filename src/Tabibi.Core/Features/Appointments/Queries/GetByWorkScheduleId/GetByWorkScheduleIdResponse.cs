using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.WorkSchedules.Entities.Appointments;

namespace Tabibi.Core.Features.Appointments.Queries.GetByWorkScheduleId
{
    public class GetByWorkScheduleIdResponse
    {
        public Guid Id {get; set;}
        public int Number { get; set; }
        public AppointmentStatus Status { get; set; }
        public Guid PatientId { get; set; }
        public PatientResponse Patient { get; set; }
    }

    public class PatientResponse
    {
        public Guid Id {get; set;}
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}