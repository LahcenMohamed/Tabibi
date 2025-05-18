using Tabibi.Domain.Abstractions;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class GeneticDisease : DiseaseBase
    {
        private GeneticDisease()
        {

        }

        public static GeneticDisease Create(string name, Guid patientId, Guid userId)
        {
            return new GeneticDisease
            {
                Name = name,
                PatientId = patientId,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }
    }
}
