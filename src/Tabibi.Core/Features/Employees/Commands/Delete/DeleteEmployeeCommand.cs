using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Employees.Commands.Delete
{
    public sealed record DeleteEmployeeCommand(Guid Id) : IRequest<Result<object>>;
}
