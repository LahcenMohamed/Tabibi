using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Update
{
    public sealed class UpdateHeightCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateHeightCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateHeightCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodPressure = _unitOfWork.HeightRepository.GetById(request.Id);
            if (bloodPressure is null)
            {
                return Result.NotFound();
            }
            bloodPressure.Update(request.Value, request.Notes, userId);
            _unitOfWork.HeightRepository.Update(bloodPressure);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
