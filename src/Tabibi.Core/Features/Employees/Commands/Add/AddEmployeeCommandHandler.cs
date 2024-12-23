using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Employees;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Employees.Commands.Add
{
    public sealed class AddEmployeeCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<AddEmployeeCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<Guid>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();

            var employee = Employee.Create(request.FullName,
                request.PhoneNumber,
                request.Email,
                request.Address,
                request.Salary,
                request.Description,
                clinicId,
                request.JobType,
                userId);
            _unitOfWork.EmployeeRepository.Add(employee);
            await _unitOfWork.SaveChangesAsync();
            return Result.Created(employee.Id);
        }
    }
}
