using Application.Employees.DTOs;
using Domain.Entities;

namespace Application.Employees.Creator
{
    public class EmployeeDTOCreator
    {
        public static EmployeeDTO Create(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            Mapper(employee, employeeDTO);

            return employeeDTO;
        }

        private static void Mapper(Employee employee, EmployeeDTO employeeDTO)
        {
            employeeDTO.Id = employee.Id;
            employeeDTO.Name = employee.Name;
            employeeDTO.ContractTypeName = employee.ContractTypeName;
            employeeDTO.HourlySalary = employee.HourlySalary;
            employeeDTO.MonthlySalary = employee.MonthlySalary;
            employeeDTO.RoleDescription = employee.RoleDescription == "" ? employee.RoleDescription : "-";
            employeeDTO.RoleId = employee.RoleId;
            employeeDTO.RoleName = employee.RoleName;

            switch (employee.ContractTypeName)
            {
                case "MonthlySalaryEmployee":
                    employeeDTO.anualSalary = employee.MonthlySalary * 12;
                    break;
                case "HourlySalaryEmployee":
                    employeeDTO.anualSalary = 120 * employee.HourlySalary * 12;
                    break;
                default:
                    break;
            }

        }
    }
}
