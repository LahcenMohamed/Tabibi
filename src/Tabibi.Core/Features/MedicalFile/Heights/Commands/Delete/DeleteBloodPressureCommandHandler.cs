using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Heights.Commands.Delete
{
    public sealed class DeleteHeightCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteHeightCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteHeightCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var height = _unitOfWork.HeightRepository.GetById(request.Id);
            if (height is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.HeightRepository.Delete(height, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
