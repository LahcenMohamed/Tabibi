using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Clinics.Entities.JobTimes
{
    public sealed class JobTime : JobTimeBase
    {
        public Guid ClinicId { get; private set; }

        private JobTime()
        {

        }

        public static JobTime Create(DayOfWeek day, TimeOnly startTime, TimeOnly endTime, Guid userId)
        {
            return new JobTime
            {
                Day = day,
                StartTime = startTime,
                EndTime = endTime,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(DayOfWeek day, TimeOnly startTime, TimeOnly endTime, Guid userId)
        {
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;

        }
    }
}
