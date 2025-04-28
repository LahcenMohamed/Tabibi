using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Appointments.Commands.Delete;

public sealed class DeleteAppointmentCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    : IRequestHandler<DeleteAppointmentCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICurrentUserService _currentUserService = currentUserService;

    public async Task<Result<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var appointment = _unitOfWork.AppointmentRepository.GetById(request.Id);
        if(appointment is null)
        {
            return Result.NotFound();
        }
        _unitOfWork.AppointmentRepository.Delete(appointment, userId);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success("");
    }
}
