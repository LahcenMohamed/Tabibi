using System;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.WorkSchedules.Entities.Appointments
{
    public sealed class Appointment : FullAuditedEntity
    {
        public int Number { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid WorkScheduleId { get; private set; }
        public Patient Patient { get; private set; }

        private Appointment() { }

        public static Appointment Create(int number, Guid patientId, Guid workScheduleId, Guid userId)
        {
            return new Appointment
            {
                Number = number,
                PatientId = patientId,
                WorkScheduleId = workScheduleId,
                Status = AppointmentStatus.Panding,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(int number, Guid workScheduleId, Guid userId)
        {
            Number = number;
            WorkScheduleId = workScheduleId;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }

        public void Confirm(Guid userId)
        {
            Status = AppointmentStatus.Confirmed;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }
        public void Cancel(Guid userId)
        {
            Status = AppointmentStatus.Canceld;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }
    }

    public enum AppointmentStatus : byte
    {
        Canceld,
        Panding,
        Confirmed
    }
}
