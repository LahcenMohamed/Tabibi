using Tabibi.Domain.Patients.Entities;

namespace Tabibi.Core.Shared.Interfaces.Repositories
{
    public interface IChronicDiseaseRepository
    {
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, string name);
        Task<IQueryable<ChronicDisease>> GetByPatientIdAsync(Guid patientId);
    }
}