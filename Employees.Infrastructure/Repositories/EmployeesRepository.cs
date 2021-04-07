using Application.Common.Interfaces;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {

        public async Task <IEnumerable<Employee>> GetEmployees()
        {

            IEnumerable<Employee> employees = new List<Employee>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");

                    var response = client.GetAsync("Employees");
                    response.Wait();

                    if (response.Result.IsSuccessStatusCode)
                    { 
                        employees = await Task.Run( () => JsonConvert.DeserializeObject<List<Employee>>(response.Result.Content.ReadAsStringAsync().Result));
                    }

                    return employees;

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
