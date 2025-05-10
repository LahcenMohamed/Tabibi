using MediatR;
using System.Net;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;
using Tabibi.Infrastructure.Features.Patients;

namespace Tabibi.Core.Features.Patients.Queries.GetRelatives
{
    public sealed class GetRelativesQueryHandler : IRequestHandler<GetRelativesQuery, Result<List<GetRelativesResponse>>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetRelativesQueryHandler(
            IPatientRepository patientRepository,
            ICurrentUserService currentUserService)
        {
            _patientRepository = patientRepository;
            _currentUserService = currentUserService;
        }

        public async Task<Result<List<GetRelativesResponse>>> Handle(GetRelativesQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var relatives = await _patientRepository.GetRelativesByUserIdAsync(userId);

            var response = relatives.Select(r => new GetRelativesResponse
            {
                Id = r.Id,
                FullName = r.FullName,
                Gender = r.Gender.ToString(),
                BirthDate = r.BirthDate,
                State = r.State,
                City = r.City,
                PhoneNumber = r.PhoneNumber,
                Email = r.Email,
                FamilyLink = r.FamilyLink?.ToString() ?? string.Empty
            }).ToList();

            return Result.Success(response);
        }
    }
}