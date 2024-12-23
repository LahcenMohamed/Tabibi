using MediatR;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Core.Features.Employees.Commands.Update
{
    public sealed record UpdateEmployeeCommand(
        Guid Id,
        FullName FullName,
        string PhoneNumber,
        string? Email,
        string? Address,
        decimal Salary,
        JobType JobType,
        string? Description) : IRequest<Result<Guid>>;
}
