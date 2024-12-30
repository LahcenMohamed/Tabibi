using Tabibi.Domain.Shared.Entities;

namespace Tabibi.Domain.Patients.Entities
{
    public sealed class BloodPressure : FullAuditedEntity
    {
        public decimal MinValue { get; private set; }
        public decimal MaxValue { get; private set; }
        public string? Notes { get; private set; }
        public Guid PatientId { get; private set; }

        // Private constructor to enforce the use of the Create method
        private BloodPressure() { }

        // Create method to instantiate a new BloodPressure object
        public static BloodPressure Create(
            decimal minValue,
            decimal maxValue,
            string? notes,
            Guid patientId,
            Guid userId)
        {
            return new BloodPressure
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Notes = notes,
                PatientId = patientId,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow,
                CreatedBy = userId
            };
        }

        // Update method to modify an existing BloodPressure object
        public void Update(decimal minValue, decimal maxValue, string? notes, Guid userId)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Notes = notes;
            LastModifiedAt = DateTime.UtcNow;
            LastModifiedBy = userId;
        }
    }
}
