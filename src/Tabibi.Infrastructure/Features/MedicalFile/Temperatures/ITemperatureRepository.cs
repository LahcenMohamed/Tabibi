using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Temperatures
{
    public interface ITemperatureRepository : IBaseRepository<Temperature>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}