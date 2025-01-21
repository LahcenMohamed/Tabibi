namespace Tabibi.Core.Features.MedicalFile.Weights.Queries
{
    public sealed class GetWeightsQueryResponse
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}