using MediatR;
using Tabibi.Domain.Patients;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Patients.Commands.AddRelative
{
    public sealed record AddRelativePatientCommand(
        string FullName,
        Gender Gender,
        DateOnly BirthDate,
        string? PhoneNumber,
        string? Email,
        string? State,
        string? City,
        FamilyLink FamilyLink) : IRequest<Result<Guid>>;
}
