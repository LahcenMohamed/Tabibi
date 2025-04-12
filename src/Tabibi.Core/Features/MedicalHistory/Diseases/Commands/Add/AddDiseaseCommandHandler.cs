using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Patients.Entities;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Commands.Add
{
    public sealed class AddDiseaseCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddDiseaseCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(AddDiseaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var disease = Disease.Create(
                request.Name,
                request.StartDate,
                request.EndDate,
                request.PatientId,
                userId);
                
            _unitOfWork.DiseaseRepository.Add(disease);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(disease.Id);
        }
    }
}