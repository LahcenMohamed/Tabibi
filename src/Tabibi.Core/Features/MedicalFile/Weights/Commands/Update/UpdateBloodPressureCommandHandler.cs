using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalFile.Weights.Commands.Update
{
    public sealed class UpdateWeightCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateWeightCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateWeightCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var weight = _unitOfWork.WeightRepository.GetById(request.Id);
            if (weight is null)
            {
                return Result.NotFound();
            }
            weight.Update(request.Value, request.Notes, userId);
            _unitOfWork.WeightRepository.Update(weight);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(string.Empty);
        }
    }
}
