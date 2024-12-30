using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalFile.BloodSugars.Queries
{
    public sealed class GetBloodSugarsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetBloodSugarsQuery, Result<List<GetBloodSugarsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<List<GetBloodSugarsQueryResponse>>> Handle(GetBloodSugarsQuery request, CancellationToken cancellationToken)
        {
            var bloodSugars = _unitOfWork.BloodSugarRepository.GetByPatientId<GetBloodSugarsQueryResponse>(request.PatientId);
            return bloodSugars.ToList();
        }
    }
}