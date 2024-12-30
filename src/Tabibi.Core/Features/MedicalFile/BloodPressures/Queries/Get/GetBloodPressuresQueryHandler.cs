using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodPressures.Queries.Get
{
    public sealed class GetBloodPressuresQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetBloodPressuresQuery, Result<List<GetBloodPressuresQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetBloodPressuresQueryResponse>>> Handle(GetBloodPressuresQuery request, CancellationToken cancellationToken)
        {
            var bloodPressures = _unitOfWork.BloodPressureRepository.GetByPatientId<GetBloodPressuresQueryResponse>(request.PatientId);
            return bloodPressures.ToList();
        }
    }
}
