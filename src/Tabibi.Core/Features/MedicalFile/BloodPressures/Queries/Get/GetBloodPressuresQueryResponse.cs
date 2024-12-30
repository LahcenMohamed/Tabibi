namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get
{
    public sealed class GetBloodPressuresQueryResponse
    {
        public Guid Id { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public string? Notes { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
