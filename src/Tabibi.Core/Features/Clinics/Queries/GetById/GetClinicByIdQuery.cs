using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Clinics.Queries.GetById
{
    public sealed record GetClinicByIdQuery(Guid Id) : IRequest<Result<GetClinicByIdQueryResponse>>;
}
