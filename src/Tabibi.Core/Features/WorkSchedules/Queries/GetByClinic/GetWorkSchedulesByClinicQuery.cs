using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetByClinic;

public sealed record GetWorkSchedulesByClinicQuery(Guid ClinicId) : IRequest<Result<List<GetWorkSchedulesByClinicResponse>>>;