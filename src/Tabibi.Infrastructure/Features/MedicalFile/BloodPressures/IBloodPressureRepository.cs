using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.BloodPressures
{
    public interface IBloodPressureRepository : IBaseRepository<BloodPressure>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}
