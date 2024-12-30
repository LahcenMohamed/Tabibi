namespace Tabibi.Core.Features.MedicalFile.Temperatures.Queries
{
    public sealed class GetTemperaturesQueryResponse
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string? Notes { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}