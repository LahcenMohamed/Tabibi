using Tabibi.Domain.Patients;
using Tabibi.Domain.Shared.Enums;

namespace Tabibi.Core.Features.Patients.Queries.GetOwner;

public sealed record GetOwnerPatientResponse(
    Guid Id,
    string FullName,
    Gender Gender,
    DateOnly BirthDate,
    string? State,
    string? City,
    string? PhoneNumber,
    string? Email);

public static class GetOwnerPatientResponseMapper
{
    public static GetOwnerPatientResponse ToResponse(Patient patient)
    {
        return new GetOwnerPatientResponse(
            patient.Id,
            patient.FullName,
            patient.Gender,
            patient.BirthDate,
            patient.State,
            patient.City,
            patient.PhoneNumber,
            patient.Email);
    }
}