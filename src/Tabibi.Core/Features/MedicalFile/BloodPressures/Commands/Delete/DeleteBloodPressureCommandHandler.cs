using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Delete
{
    public sealed class DeleteBloodPressureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteBloodPressureCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteBloodPressureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodPressure = _unitOfWork.BloodPressureRepository.GetById(request.Id);
            if (bloodPressure is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.BloodPressureRepository.Delete(bloodPressure, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
