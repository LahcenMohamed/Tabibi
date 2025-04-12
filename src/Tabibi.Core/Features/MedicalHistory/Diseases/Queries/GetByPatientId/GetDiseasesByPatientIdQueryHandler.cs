using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Diseases.Queries.GetByPatientId
{
    public sealed class GetDiseasesByPatientIdQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetDiseasesByPatientIdQuery, Result<IQueryable<DiseaseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<IQueryable<DiseaseDto>>> Handle(GetDiseasesByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var diseases = _unitOfWork.DiseaseRepository.GetByPatientId<DiseaseDto>(request.PatientId);

            return Result.Success(diseases);
        }
    }
}