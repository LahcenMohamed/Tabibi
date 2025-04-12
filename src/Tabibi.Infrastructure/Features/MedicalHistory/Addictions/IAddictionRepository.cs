using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.Addictions
{
    public interface IAddictionRepository : IBaseRepository<Addiction>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
