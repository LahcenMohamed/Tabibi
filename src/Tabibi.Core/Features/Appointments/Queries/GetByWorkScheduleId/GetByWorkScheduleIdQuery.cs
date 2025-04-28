using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Queries.GetByWorkScheduleId
{
    public sealed record GetByWorkScheduleIdQuery(Guid WorkScheduleId) : IRequest<Result<IQueryable<GetByWorkScheduleIdResponse>>>;
}