using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Commands.Add
{
    public sealed class AddGeneticDiseasesCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddGeneticDiseasesCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddGeneticDiseasesCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var chronicDisease = GeneticDisease.Create(request.DiseaseName, request.PatientId, userId);
            _unitOfWork.GeneticDiseaseRepository.Add(chronicDisease);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(chronicDisease.Id);
        }
    }
}