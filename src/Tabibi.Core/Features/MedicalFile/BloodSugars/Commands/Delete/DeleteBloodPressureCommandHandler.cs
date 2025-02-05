using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Delete
{
    public sealed class DeleteBloodSugarCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteBloodSugarCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteBloodSugarCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodSugar = _unitOfWork.BloodSugarRepository.GetById(request.Id);
            if (bloodSugar is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.BloodSugarRepository.Delete(bloodSugar, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
