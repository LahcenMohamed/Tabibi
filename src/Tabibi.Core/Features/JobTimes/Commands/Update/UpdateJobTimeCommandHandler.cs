using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.JobTimes.Commands.Update
{
    public sealed class UpdateJobTimeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<UpdateJobTimeCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(UpdateJobTimeCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var clinicId = _currentUserService.GetClinicId();
            var jobTime = _unitOfWork.JobTimeRepository.GetById(request.Id);

            if (jobTime is null || jobTime.ClinicId != clinicId)
            {
                return Result.NotFound<string>("Job Time Not Found");
            }

            jobTime.Update(request.Day, request.StartTime, request.EndTime, userId);
            _unitOfWork.JobTimeRepository.Update(jobTime);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success<string>(null);
        }
    }
}
