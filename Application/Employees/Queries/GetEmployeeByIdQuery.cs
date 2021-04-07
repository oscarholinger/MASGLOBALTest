using Application.Employees.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<List<EmployeeDTO>>
    {
        public int EmployeeId { get; }

        public GetEmployeeByIdQuery(int EmployeeId)
        {
            this.EmployeeId = EmployeeId;
        }
    }
}
