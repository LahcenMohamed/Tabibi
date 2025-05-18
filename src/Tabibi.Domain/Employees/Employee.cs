using Tabibi.Domain.Employees.Entities.EmployeeJobTimes;
using Tabibi.Domain.Shared.AggregateRoots;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Domain.Employees
{
    public sealed class Employee : FullAuditedAggregateRoot
    {
        public FullName FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public decimal Salary { get; private set; }
        public string? Description { get; private set; }
        public Guid ClinicId { get; private set; }
        public JobType JobType { get; private set; }
        public List<EmployeeJobTime> JobTimes { get; private set; }

        private Employee()
        {

        }

        public static Employee Create(
        FullName fullName,
        string phoneNumber,
        string? email,
        string? address,
        decimal salary,
        string? description,
        Guid clinicId,
        JobType jobType,
        Guid userId)
        {

            var employee = new Employee
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                Salary = salary,
                Description = description,
                ClinicId = clinicId,
                JobType = jobType,
                CreatedBy = userId,
                CreatedAt = DateTime.Now,
            };

            return employee;
        }

        public void Update(
            FullName fullName,
            string phoneNumber,
            string? email,
            string? address,
            decimal salary,
            string? description,
            JobType jobType,
            Guid userId)
        {

            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Salary = salary;
            Description = description;
            JobType = jobType;
            LastModifiedBy = userId;
            LastModifiedAt = DateTime.Now;
        }
    }

    public enum JobType : byte
    {
        Doctor,
        Nurse,
        NursingAssistant,
        Receptionist,
        Janitor,
        Other
    }
}
