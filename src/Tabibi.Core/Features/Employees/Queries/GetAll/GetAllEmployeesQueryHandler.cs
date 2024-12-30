using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Employees.Queries.GetAll
{
    public sealed class GetAllEmployeesQueryHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllEmployeesQuery, Result<List<GetAllEmployeesQueryResponse>>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<List<GetAllEmployeesQueryResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var lst = _unitOfWork.EmployeeRepository.GetByClinicId<GetAllEmployeesQueryResponse>(clinicId);
            return lst.ToList();
        }
    }
}
