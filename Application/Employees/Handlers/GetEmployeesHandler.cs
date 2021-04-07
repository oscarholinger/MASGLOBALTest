using Application.Common.Interfaces;
using Application.Employees.DTOs;
using Application.Employees.Queries;
using Application.Employees.Creator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, List<EmployeeDTO>>
    {

        private readonly IEmployeesRepository _employeesRepository;

        public GetEmployeesHandler(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository ??
                throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeesRepository.GetEmployees();

            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                employeeDTOList.Add(EmployeeDTOCreator.Create(employee));
            }

            return employeeDTOList;
            
        }
    }
}
