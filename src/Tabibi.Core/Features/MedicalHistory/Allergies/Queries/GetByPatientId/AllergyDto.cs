namespace Tabibi.Core.Features.MedicalHistory.Allergies.Queries.GetByPatientId
{
    public sealed class AllergyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid PatientId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}