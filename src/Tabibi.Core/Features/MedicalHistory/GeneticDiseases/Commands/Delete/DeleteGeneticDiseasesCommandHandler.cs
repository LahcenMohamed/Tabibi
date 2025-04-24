using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Delete
{
    public sealed class DeleteGeneticDiseasesCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<DeleteGeneticDiseasesCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(DeleteGeneticDiseasesCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var chronicDisease = _unitOfWork.GeneticDiseaseRepository.GetById(request.Id);
            if (chronicDisease is null)
            {
                return Result.NotFound();
            }
            _unitOfWork.GeneticDiseaseRepository.Delete(chronicDisease, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}