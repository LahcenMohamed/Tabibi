using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Commands.Update
{
    public sealed class UpdateBloodSugarCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateBloodSugarCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateBloodSugarCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var bloodSugar = _unitOfWork.BloodSugarRepository.GetById(request.Id);
            if (bloodSugar is null)
            {
                return Result.NotFound();
            }
            bloodSugar.Update(request.Value, request.Notes, userId);
            _unitOfWork.BloodSugarRepository.Update(bloodSugar);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
