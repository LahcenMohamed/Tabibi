namespace Tabibi.Core.Features.MedicalHistory.Addictions.Queries.GetByPatientId
{
    public sealed class AddictionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PatientId { get; set; }
    }
}