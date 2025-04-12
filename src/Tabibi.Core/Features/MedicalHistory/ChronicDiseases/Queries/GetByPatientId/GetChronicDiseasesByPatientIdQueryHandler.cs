using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.ChronicDiseases.Queries.GetByPatientId
{
    public class GetChronicDiseasesByPatientIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<GetChronicDiseasesByPatientIdQuery, Result<IQueryable<ChronicDiseasesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<IQueryable<ChronicDiseasesResponse>>> Handle(
            GetChronicDiseasesByPatientIdQuery request,
            CancellationToken cancellationToken)
        {
            var lst = _unitOfWork.ChronicDiseaseRepository.GetByPatientId<ChronicDiseasesResponse>(request.PatientId);
            return Result.Success(lst);
        }
    }
}