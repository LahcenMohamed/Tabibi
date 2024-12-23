using MediatR;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Infrastructure.Features.CurrentUser;

namespace Tabibi.Core.Features.Employees.Commands.Delete
{
    public sealed class DeleteEmployeeCommandHandler(ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteEmployeeCommand, Result<object>>
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<object>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var clinicId = _currentUserService.GetClinicId();
            var userId = _currentUserService.GetUserId();

            var employee = _unitOfWork.EmployeeRepository.GetById(clinicId);
            if (employee is null || employee.ClinicId != clinicId)
            {
                return Result.NotFound<object>(null);
            }

            _unitOfWork.EmployeeRepository.Delete(employee, userId);
            await _unitOfWork.SaveChangesAsync();
            return Result.Deleted<object>();
        }
    }
}
