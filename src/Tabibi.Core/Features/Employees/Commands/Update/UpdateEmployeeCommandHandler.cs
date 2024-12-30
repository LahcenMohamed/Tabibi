using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Employees.Commands.Update
{
    internal class UpdateEmployeeCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateEmployeeCommand, Result<Guid>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<Guid>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();

            var employee = _unitOfWork.EmployeeRepository.GetById(request.Id);
            if (employee is null || employee.ClinicId != clinicId)
            {
                return Result.NotFound();
            }

            employee.Update(request.FullName,
                            request.PhoneNumber,
                            request.Email,
                            request.Address,
                            request.Salary,
                            request.Description,
                            request.JobType,
                            userId);
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.SaveChangesAsync();
            return employee.Id;
        }
    }
}
