using MediatR;
using Tabibi.Domain.Shared.Enums;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Patients.Commands.Add
{
    public sealed record AddPatientCommand(
        string FullName,
        Gender Gender,
        DateOnly BirthDate,
        string PhoneNumber,
        string Email,
        Guid UserId)
        : IRequest<Result<Guid>>;
}
