namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Queries
{
    public sealed class GetBloodSugarsQueryResponse
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string? Notes { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}