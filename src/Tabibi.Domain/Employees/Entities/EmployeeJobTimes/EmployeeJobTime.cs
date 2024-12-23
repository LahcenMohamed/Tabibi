using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Employees.Entities.EmployeeJobTimes
{
    public sealed class EmployeeJobTime : JobTimeBase
    {
        public Guid EmployeeId { get; private set; }

        private EmployeeJobTime()
        {

        }

        public static EmployeeJobTime Create(DayOfWeek day, TimeOnly startTime, TimeOnly endTime, Guid employeeId, Guid userId)
        {
            return new EmployeeJobTime
            {
                Day = day,
                StartTime = startTime,
                EndTime = endTime,
                EmployeeId = employeeId,
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
