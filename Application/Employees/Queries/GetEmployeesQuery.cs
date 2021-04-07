using Application.Employees.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Employees.Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeDTO>>
    {

    }
}
