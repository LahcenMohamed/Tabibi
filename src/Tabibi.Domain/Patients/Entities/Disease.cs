using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class Disease : FullAuditedEntity
    {
        public string Name { get; private set; }
        public Guid PatientId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        private Disease()
        {

        }

        public static Disease Create(
            string name,
            DateOnly startDate,
            DateOnly endDate,
            Guid patientId,
            Guid userId)
        {
            return new Disease
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                PatientId = patientId,
                CreatedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(string name, DateOnly startDate, DateOnly endDate, Guid userId)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }
    }
}
