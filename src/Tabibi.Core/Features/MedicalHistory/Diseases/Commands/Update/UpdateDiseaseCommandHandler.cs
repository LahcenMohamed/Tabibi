using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Update
{
    public sealed class UpdateDiseaseCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<UpdateDiseaseCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(UpdateDiseaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var disease = _unitOfWork.DiseaseRepository.GetById(request.Id);
            if (disease is null)
            {
                return Result.NotFound($"Disease with ID {request.Id} not found");
            }

            disease.Update(
                request.Name,
                request.StartDate,
                request.EndDate,
                userId);

            _unitOfWork.DiseaseRepository.Update(disease);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}