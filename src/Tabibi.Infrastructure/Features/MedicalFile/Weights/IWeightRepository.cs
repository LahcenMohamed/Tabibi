using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Weights
{
    public interface IWeightRepository : IBaseRepository<Weight>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}