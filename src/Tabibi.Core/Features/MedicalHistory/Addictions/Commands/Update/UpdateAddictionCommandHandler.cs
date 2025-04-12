using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Update
{
    public sealed class UpdateAddictionCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateAddictionCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(UpdateAddictionCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var addiction = _unitOfWork.AddictionRepository.GetById(request.Id);

            if (addiction is null)
                return Result.NotFound("Addiction not found");

            addiction.Update(request.Name, userId);
            _unitOfWork.AddictionRepository.Update(addiction);
            await _unitOfWork.SaveChangesAsync();

            return Result.Deleted<string>();
        }
    }
}