namespace Tabibi.Core.Features.Patients.Queries.GetRelatives
{
    public sealed class GetRelativesResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string FamilyLink { get; set; }
    }
}