using Tabibi.Domain.Abstractions;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class ChronicDisease : DiseaseBase
    {
        private ChronicDisease()
        {

        }

        public static ChronicDisease Create(string name, Guid patientId, Guid userId)
        {
            return new ChronicDisease
            {
                Name = name,
                PatientId = patientId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
        }
    }
}
