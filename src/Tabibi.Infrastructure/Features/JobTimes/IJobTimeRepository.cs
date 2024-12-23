using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.JobTimes
{
    public interface IJobTimeRepository : IBaseRepository<JobTime>
    {
        IQueryable<TResponse> GetByClinicId<TResponse>(Guid clinicId);
    }
}
