using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.Diseases
{
    public interface IDiseaseRepository : IBaseRepository<Disease>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
