using Tabibi.Domain.Abstractions;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class Addiction : DiseaseBase
    {
        private Addiction()
        {

        }

        public static Addiction Create(string name, Guid patientId, Guid userId)
        {
            return new Addiction
            {
                Name = name,
                PatientId = patientId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
        }
    }
}
