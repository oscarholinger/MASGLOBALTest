using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
