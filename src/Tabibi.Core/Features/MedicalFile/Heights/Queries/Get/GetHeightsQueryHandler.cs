using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.Heights.Queries
{
    public sealed class GetHeightsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetHeightsQuery, Result<List<GetHeightsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetHeightsQueryResponse>>> Handle(GetHeightsQuery request, CancellationToken cancellationToken)
        {
            var heights = _unitOfWork.HeightRepository.GetByPatientId<GetHeightsQueryResponse>(request.PatientId);
            return heights.ToList();
        }
    }
}