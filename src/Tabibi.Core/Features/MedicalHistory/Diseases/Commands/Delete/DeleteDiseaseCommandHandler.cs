using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Delete
{
    public sealed class DeleteDiseaseCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<DeleteDiseaseCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var disease = _unitOfWork.DiseaseRepository.GetById(request.Id);
            if (disease is null)
            {
                return Result.NotFound($"Disease with ID {request.Id} not found");
            }

            _unitOfWork.DiseaseRepository.Delete(disease, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}