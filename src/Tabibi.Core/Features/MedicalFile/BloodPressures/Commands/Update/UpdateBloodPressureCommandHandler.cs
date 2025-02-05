using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Commands.Update
{
    public sealed class UpdateBloodPressureCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateBloodPressureCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateBloodPressureCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodPressure = _unitOfWork.BloodPressureRepository.GetById(request.Id);
            if (bloodPressure is null)
            {
                return Result.NotFound();
            }
            bloodPressure.Update(request.MinValue, request.MaxValue, request.Notes, userId);
            _unitOfWork.BloodPressureRepository.Update(bloodPressure);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
