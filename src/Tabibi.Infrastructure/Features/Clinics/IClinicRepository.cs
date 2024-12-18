using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Clinics;

public interface IClinicRepository : IBaseRepository<Clinic>
{
    IQueryable<TResponse> GetAllByDapper<TResponse>(Specialization specialization, string state, string city);
}
