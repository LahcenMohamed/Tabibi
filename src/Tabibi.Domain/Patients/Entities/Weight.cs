using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class Weight : FullAuditedEntity
    {
        public decimal Value { get; private set; }
        public string? Notes { get; private set; }
        public Guid PatientId { get; private set; }

        private Weight() { }

        public static Weight Create(
            decimal value,
            string? notes,
            Guid patientId,
            Guid userId)
        {
            return new Weight
            {
                Value = value,
                Notes = notes,
                PatientId = patientId,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now,
                CreatedBy = userId
            };
        }

        public void Update(decimal value, string? notes, Guid userId)
        {
            Value = value;
            Notes = notes;
            LastModifiedAt = DateTime.Now;
            LastModifiedBy = userId;
        }
    }
}
