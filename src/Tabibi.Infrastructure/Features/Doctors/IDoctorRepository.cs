using Tabibi.Domain.Clinics.Entities.Doctors;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Doctors
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        IQueryable<TResponse> GetAllByDapper<TResponse>();
    }
}
