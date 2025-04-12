using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Addictions.Queries.GetByPatientId
{
    public sealed class GetAddictionsByPatientIdQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetAddictionsByPatientIdQuery, Result<List<AddictionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<AddictionDto>>> Handle(GetAddictionsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var addictions = _unitOfWork.AddictionRepository.GetByPatientId<AddictionDto>(request.PatientId).ToList();
            return Result.Success(addictions);
        }
    }
}