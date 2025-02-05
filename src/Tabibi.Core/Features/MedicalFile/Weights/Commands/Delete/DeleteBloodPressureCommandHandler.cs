using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Delete
{
    public sealed class DeleteWeightCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteWeightCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteWeightCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var weight = _unitOfWork.WeightRepository.GetById(request.Id);
            if (weight is null)
            {
                return Result.NotFound();
            }

            _unitOfWork.WeightRepository.Delete(weight, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
