using Application.Common.Interfaces;
using Application.Employees.Creator;
using Application.Employees.DTOs;
using Application.Employees.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public GetEmployeeByIdHandler(IEmployeesRepository employeeRepository)
        {
            _employeesRepository = employeeRepository ??
                throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeesRepository.GetEmployees();

            Employee employee = employees.Where(x => x.Id == request.EmployeeId).FirstOrDefault();

            List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO> { };

            if (employee != null)
            {
                employeeDTOList.Add(EmployeeDTOCreator.Create(employee));
            }

            return employeeDTOList;
        }
    }
}
