using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        ActionResult<IEnumerable<Employee>> GetEmployees();
        Task GetEmployeeById(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
