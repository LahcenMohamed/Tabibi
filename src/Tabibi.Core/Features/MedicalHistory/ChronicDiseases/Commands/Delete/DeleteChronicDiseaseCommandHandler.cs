using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Delete
{
    public sealed class DeleteChronicDiseaseCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<DeleteChronicDiseaseCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(DeleteChronicDiseaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var chronicDisease = _unitOfWork.ChronicDiseaseRepository.GetById(request.Id);
            if (chronicDisease is null)
            {
                return Result.NotFound();
            }
            _unitOfWork.ChronicDiseaseRepository.Delete(chronicDisease, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}