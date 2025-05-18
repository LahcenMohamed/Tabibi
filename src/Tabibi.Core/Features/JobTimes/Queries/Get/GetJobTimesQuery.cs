using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.JobTimes.Queries.Get
{
    public sealed record GetJobTimesQuery : IRequest<Result<IQueryable<JobTimeResponse>>>;
}