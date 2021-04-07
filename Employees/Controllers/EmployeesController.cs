using Application.Employees.DTOs;
using Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var query = new GetEmployeesQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<List<EmployeeDTO>> GetEmployee(int id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
