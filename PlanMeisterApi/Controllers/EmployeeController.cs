using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var employees = await _employeeService.GetAllEmployees();
        if (employees == null) return NotFound();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
    {
        try
        {
            await _employeeService.AddEmployee(employee);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeId) return BadRequest();

        try
        {
            await _employeeService.UpdateEmployee(employee);
        }
        catch (Exception ex)
        {
            if (!await _employeeService.EmployeeExists(id))
                return NotFound();
            throw ex;
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee == null) return NotFound();

        await _employeeService.DeleteEmployee(employee.EmployeeId);

        return NoContent();
    }
}