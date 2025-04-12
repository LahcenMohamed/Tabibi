using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Commands.Delete
{
    public sealed class DeleteAddictionCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteAddictionCommand, Result<string>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> Handle(DeleteAddictionCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var addiction = _unitOfWork.AddictionRepository.GetById(request.Id);

            if (addiction is null)
                return Result.NotFound("Addiction not found");

            _unitOfWork.AddictionRepository.Delete(addiction, userId);
            await _unitOfWork.SaveChangesAsync();

            return Result.Deleted<string>();
        }
    }
}