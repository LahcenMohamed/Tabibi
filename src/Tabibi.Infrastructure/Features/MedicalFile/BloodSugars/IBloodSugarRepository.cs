using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.BloodSugars
{
    public interface IBloodSugarRepository : IBaseRepository<BloodSugar>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}