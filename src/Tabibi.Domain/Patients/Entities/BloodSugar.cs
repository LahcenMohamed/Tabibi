using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class BloodSugar : FullAuditedEntity
    {
        public decimal Value { get; private set; }
        public string? Notes { get; private set; }
        public Guid PatientId { get; private set; }

        private BloodSugar() { }

        public static BloodSugar Create(
            decimal value,
            string? notes,
            Guid patientId,
            Guid userId)
        {
            return new BloodSugar
            {
                Value = value,
                Notes = notes,
                PatientId = patientId,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
        }

        public void Update(decimal value, string? notes, Guid userId)
        {
            Value = value;
            Notes = notes;
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedBy = userId;
        }
    }
}
