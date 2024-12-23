using Tabibi.Domain.Employees;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Employees
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IQueryable<TResponse> GetByClinicId<TResponse>(Guid clinicId);
    }
}
