using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.GeneticDiseases
{
    public interface IGeneticDiseaseRepository : IBaseRepository<GeneticDisease>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
