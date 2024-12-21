using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Clinics.Entities.JobTimes;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.JobTimes.Commands.Add
{
    public sealed class AddJobTimeCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<AddJobTimeCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<Guid>> Handle(AddJobTimeCommand request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();
            var jobTime = JobTime.Create(request.Day,
                                         request.StartTime,
                                         request.EndTime,
                                         clinicId,
                                         userId);

            _unitOfWork.JobTimeRepository.Add(jobTime);
            await _unitOfWork.SaveChangesAsync();

            return Result.Created(jobTime.Id);
        }
    }
}
