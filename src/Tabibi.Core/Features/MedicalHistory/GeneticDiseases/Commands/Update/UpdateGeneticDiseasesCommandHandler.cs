using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Update
{
    public sealed class UpdateGeneticDiseasesCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<UpdateGeneticDiseasesCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(UpdateGeneticDiseasesCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var geneticDiseases = _unitOfWork.GeneticDiseaseRepository.GetById(request.Id);
            if (geneticDiseases is null)
            {
                return Result.NotFound();
            }

            geneticDiseases.Update(request.Name, userId);
            _unitOfWork.GeneticDiseaseRepository.Update(geneticDiseases);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}