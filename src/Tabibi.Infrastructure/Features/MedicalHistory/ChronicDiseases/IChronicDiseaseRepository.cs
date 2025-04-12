using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.ChronicDiseases
{
    public interface IChronicDiseaseRepository : IBaseRepository<ChronicDisease>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
