using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Commands.Add
{
    public sealed class AddChronicDiseasesCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddChronicDiseasesCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddChronicDiseasesCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var chronicDisease = ChronicDisease.Create(request.DiseaseName, request.PatientId, userId);
            _unitOfWork.ChronicDiseaseRepository.Add(chronicDisease);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(chronicDisease.Id);
        }
    }
}