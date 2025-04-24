using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.MedicalHistory.GeneticDiseases.Queries.GetByPaitentId
{
    public sealed class GetGeneticDiseasesByPatientIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        : IRequestHandler<GetGeneticDiseasesByPatientIdQuery, Result<IQueryable<GeneticDiseasesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<Result<IQueryable<GeneticDiseasesResponse>>> Handle(
            GetGeneticDiseasesByPatientIdQuery request,
            CancellationToken cancellationToken)
        {
            var lst = _unitOfWork.ChronicDiseaseRepository.GetByPatientId<GeneticDiseasesResponse>(request.PatientId);
            return Result.Success(lst);
        }
    }
}