using Tabibi.Domain.Employees;

namespace Tabibi.Core.Features.Employees.Queries.GetAll
{
    public sealed class GetAllEmployeesQueryResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public JobType JobType { get; set; }
        public string? Description { get; set; }
    }
}
