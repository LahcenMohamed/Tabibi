using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;
using Tabibi.Infrastructure.Features.Patients;

namespace Tabibi.Core.Features.Patients.Queries.GetOwner;

public sealed class GetOwnerPatientQueryHandler : IRequestHandler<GetOwnerPatientQuery, Result<GetOwnerPatientResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public GetOwnerPatientQueryHandler(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task<Result<GetOwnerPatientResponse>> Handle(GetOwnerPatientQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var patient = await _unitOfWork.PatientRepository.GetOwnerByUserIdAsync(userId);

        if (patient is null)
            throw new Exception("Owner patient not found");

        return Result.Success(GetOwnerPatientResponseMapper.ToResponse(patient));
    }
}