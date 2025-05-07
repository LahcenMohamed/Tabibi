using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riok.Mapperly.Abstractions;
using Tabibi.Domain.Employees;

namespace Tabibi.Core.Features.Employees.Queries.GetAll
{
    [Mapper]
    public static partial class GetEmployeesMapper
    {
        public static partial IQueryable<GetAllEmployeesQueryResponse> ToDto(this IQueryable<Employee> employees);
    }
}