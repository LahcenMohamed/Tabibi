namespace Tabibi.Core.Features.MedicalFile.Abstractions
{
    public abstract class GetMedicalFileResponse
    {
        public Guid Id { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
