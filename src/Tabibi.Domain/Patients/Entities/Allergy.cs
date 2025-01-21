using Tabibi.Domain.Abstractions;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class Allergy : DiseaseBase
    {
        private Allergy()
        {

        }

        public static Allergy Create(string name, Guid patientId, Guid userId)
        {
            return new Allergy
            {
                Name = name,
                PatientId = patientId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
        }
    }
}
