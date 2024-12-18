using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Doctors.Queries.GetAll
{
    public sealed record GetAllDoctorsQuery : IRequest<Result<List<GetAllDoctorsQueryResponse>>>;
}
