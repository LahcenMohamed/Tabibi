using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Employees.Queries.GetAll
{
    public sealed record GetAllEmployeesQuery : IRequest<Result<List<GetAllEmployeesQueryResponse>>>;
}
