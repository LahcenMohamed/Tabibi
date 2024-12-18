using MediatR;
using Tabibi.Domain.Clinics.Enums;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Clinics.Queries.GetAll
{
    public sealed record GetAllClinicsQuery(Specialization Specialization, string State, string City)
        : IRequest<Result<List<GetAllClinicsQueryResponse>>>;
}
