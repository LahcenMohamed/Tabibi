namespace Tabibi.Core.Features.MedicalFile.Heights.Queries
{
    public sealed class GetHeightsQueryResponse
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}