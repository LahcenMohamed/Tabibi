using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Update
{
    public sealed class UpdateChronicDiseaseCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<UpdateChronicDiseaseCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<string>> Handle(UpdateChronicDiseaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var chronicDisease = _unitOfWork.ChronicDiseaseRepository.GetById(request.Id);
            if (chronicDisease is null)
            {
                return Result.NotFound();
            }

            chronicDisease.Update(request.Name, userId);
            _unitOfWork.ChronicDiseaseRepository.Update(chronicDisease);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("");
        }
    }
}