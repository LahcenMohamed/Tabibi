using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Commands.Delete
{
    public sealed class DeleteAllergyCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<DeleteAllergyCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(DeleteAllergyCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var allergy = _unitOfWork.AllergyRepository.GetById(request.Id);
            if (allergy is null)
            {
                return Result.NotFound($"Allergy with ID {request.Id} not found");
            }

            _unitOfWork.AllergyRepository.Delete(allergy, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Deleted<string>();
        }
    }
}