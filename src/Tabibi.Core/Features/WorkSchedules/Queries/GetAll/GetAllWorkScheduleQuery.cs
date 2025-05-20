using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

public sealed record GetAllWorkScheduleQuery() : IRequest<Result<IQueryable<GetAllWorkScheduleResponse>>>;