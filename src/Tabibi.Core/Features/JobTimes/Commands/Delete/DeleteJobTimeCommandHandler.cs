using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.JobTimes.Commands.Delete
{
    public sealed class DeleteJobTimeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<DeleteJobTimeCommand, Result<object>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<object>> Handle(DeleteJobTimeCommand request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();
            var jobTime = _unitOfWork.JobTimeRepository.GetById(request.Id);
            if (jobTime is null || jobTime.ClinicId != clinicId)
            {
                return Result.NotFound<object>(null);
            }

            _unitOfWork.JobTimeRepository.Delete(jobTime, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Deleted<object>();
        }
    }
}
