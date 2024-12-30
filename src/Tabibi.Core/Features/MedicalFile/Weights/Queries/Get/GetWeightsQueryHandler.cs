using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Weights.Queries
{
    public sealed class GetWeightsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetWeightsQuery, Result<List<GetWeightsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetWeightsQueryResponse>>> Handle(GetWeightsQuery request, CancellationToken cancellationToken)
        {
            var weights = _unitOfWork.WeightRepository.GetByPatientId<GetWeightsQueryResponse>(request.PatientId);
            return weights.ToList();
        }
    }
}