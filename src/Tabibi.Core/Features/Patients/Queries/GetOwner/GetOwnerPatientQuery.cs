using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Patients.Queries.GetOwner;

public sealed record GetOwnerPatientQuery : IRequest<Result<GetOwnerPatientResponse>>;