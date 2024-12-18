using Tabibi.Domain.Shared.Enums;

namespace Tabibi.Core.Features.Doctors.Queries.GetAll;

public sealed class GetAllDoctorsQueryResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? MiddelName { get; set; }
    public string? LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Notes { get; set; }
    public Guid ClinicId { get; set; }

}
