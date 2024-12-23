using MediatR;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Shared.ValueObjects;

namespace Tabibi.Core.Features.Employees.Commands.Add
{
    public sealed record AddEmployeeCommand(FullName FullName,
                                            string PhoneNumber,
                                            string? Email,
                                            string? Address,
                                            decimal Salary,
                                            JobType JobType,
                                            string? Description) : IRequest<Result<Guid>>;
}
