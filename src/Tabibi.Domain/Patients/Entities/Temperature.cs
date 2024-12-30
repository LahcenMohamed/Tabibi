using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class Temperature : FullAuditedEntity
    {
        public decimal Value { get; private set; }
        public string? Notes { get; private set; }
        public Guid PatientId { get; private set; }

        private Temperature() { }

        public static Temperature Create(
            decimal value,
            string? notes,
            Guid patientId,
            Guid userId)
        {
            return new Temperature
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
