using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers;

[ApiController]
[Route("employee")]

public abstract class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    public EmployeeController(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployeesValues()
    {
        var employee = _repo.GetEmployees();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public ActionResult GetEmployeeById(int id)
    {
        return Ok(_repo.GetEmployeeById(id));
    }

    [HttpPost]
    public OkObjectResult AddEmployee([FromBody] Employee employee)
    {
        _repo.AddEmployee(employee);
        return Ok(employee);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEmployee(Employee employee)
    {
        if (employee == null)
        {
            return NotFound("Getting null for student");
        }

        await _repo.UpdateEmployee(employee);
        return Ok("Value Updated");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {

        _repo.DeleteEmployee(id);
        return Ok("Value Deleted");
    }
}
