using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.WorkSchedules.Queries.GetAll;

public sealed record GetAllWorkScheduleQuery(DateOnly StartAt, DateOnly EndAt) : IRequest<Result<IQueryable<GetAllWorkScheduleResponse>>>;