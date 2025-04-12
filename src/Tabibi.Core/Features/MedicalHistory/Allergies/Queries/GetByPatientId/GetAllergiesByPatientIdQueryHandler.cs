using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;

namespace Tabibi.Core.Features.MedicalHistory.Allergies.Queries.GetByPatientId
{
    public sealed class GetAllergiesByPatientIdQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllergiesByPatientIdQuery, Result<IQueryable<AllergyDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<IQueryable<AllergyDto>>> Handle(GetAllergiesByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var allergies = _unitOfWork.AllergyRepository.GetByPatientId<AllergyDto>(request.PatientId);

            return Result.Success(allergies);
        }
    }
}