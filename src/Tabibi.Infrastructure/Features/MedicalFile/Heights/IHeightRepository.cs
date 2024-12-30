using Tabibi.Domain.Patients.Entities;
using Tabibi.Infrastructure.Shared.Repositories;

namespace Tabibi.Infrastructure.Features.MedicalFile.Heights
{
    public interface IHeightRepository : IBaseRepository<Height>
    {
        IQueryable<TResponse> GetByPatientId<TResponse>(Guid patientId);
    }
}