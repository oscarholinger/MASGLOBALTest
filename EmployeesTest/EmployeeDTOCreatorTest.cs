using Application.Common.Interfaces;
using Application.Employees.Creator;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EmployeesTest
{
    [TestClass]
    public class EmployeeDTOCreatorTest
    {
        [TestMethod]
        public void CalculateAnualSalaryTest()
        {
            // Arrange
            Employee hourlySalaryEmployee = new Employee() {
                Id = 1,
                Name = "Andrea",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "-",
                HourlySalary = 10000,
                MonthlySalary = 50000
             };

            Employee monthlySalaryEmployee = new Employee()
            {
                Id = 2,
                Name = "Alex",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 2,
                RoleName = "Contractor",
                RoleDescription = "-",
                HourlySalary = 10000,
                MonthlySalary = 50000
            };

            var expectedAnualSalaryForHourlySalary = hourlySalaryEmployee.HourlySalary * 120 * 12;
            var expectedAnualSalaryForMonthlySalary = monthlySalaryEmployee.MonthlySalary * 12;

            // Act

            var hourlySalaryEmployeeDTO = EmployeeDTOCreator.Create(hourlySalaryEmployee);
            var monthlySalaryEmployeeDTO = EmployeeDTOCreator.Create(monthlySalaryEmployee);

            var actualAnualSalaryForHourlyEmployee = hourlySalaryEmployeeDTO.anualSalary;
            var actualAnualSalaryForMonthlyEmployee = monthlySalaryEmployeeDTO.anualSalary;

            // Assert
            Assert.AreEqual(expectedAnualSalaryForHourlySalary, actualAnualSalaryForHourlyEmployee);
            Assert.AreEqual(expectedAnualSalaryForMonthlySalary, actualAnualSalaryForMonthlyEmployee);


        }

       
    }
}
