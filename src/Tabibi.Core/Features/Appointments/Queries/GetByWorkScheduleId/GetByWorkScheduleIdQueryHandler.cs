using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.Appointments.Queries.GetByWorkScheduleId
{
    public sealed class GetByWorkScheduleIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetByWorkScheduleIdQuery, Result<IQueryable<GetByWorkScheduleIdResponse>>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<IQueryable<GetByWorkScheduleIdResponse>>> Handle(GetByWorkScheduleIdQuery request, CancellationToken cancellationToken)
    {
        var lst = _unitOfWork.AppointmentRepository.GetAll()
        .Include(x => x.Patient)
        .Where(x => x.WorkScheduleId == request.WorkScheduleId)
        .ToDto();
        return Result.Success(lst);
    }
}

}