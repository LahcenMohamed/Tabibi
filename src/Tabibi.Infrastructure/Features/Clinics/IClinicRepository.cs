using Tabibi.Domain.Clinics;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.Clinics;

public interface IClinicRepository : IBaseRepository<Clinic>
{
    IQueryable<TResponse> GetAllWithDto<TResponse>(Specialization specialization, string state, string city);
    TResponse GetByIdWithDto<TResponse>(Guid id);
    Clinic GetByUserId(Guid userId);
}
