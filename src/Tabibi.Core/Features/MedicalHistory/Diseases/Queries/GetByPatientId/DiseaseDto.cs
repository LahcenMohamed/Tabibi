namespace Tabibi.Core.Features.MedicalHistory.Diseases.Queries.GetByPatientId
{
    public sealed class DiseaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid PatientId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}