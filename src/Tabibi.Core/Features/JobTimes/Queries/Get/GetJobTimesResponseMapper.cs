using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riok.Mapperly.Abstractions;
using Tabibi.Domain.Clinics.Entities.JobTimes;

namespace Tabibi.Core.Features.JobTimes.Queries.Get
{
    [Mapper]
    public static partial class GetJobTimesResponseMapper
    {
        public static partial IQueryable<JobTimeResponse> ToDto(this IQueryable<JobTime> jobTimes);
    }
}