using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalHistory.Allergies
{
    public interface IAllergyRepository : IBaseRepository<Allergy>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
