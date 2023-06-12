using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _employeeRepository.GetEmployeeById(employeeId);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _employeeRepository.GetAllEmployees();
    }

    public async Task AddEmployee(Employee employee)
    {
        await _employeeRepository.AddEmployee(employee);
    }

    public async Task UpdateEmployee(Employee employee)
    {
        if (!await _employeeRepository.EmployeeExists(employee.EmployeeId)) throw new Exception("Employee not found.");
        await _employeeRepository.UpdateEmployee(employee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        await _employeeRepository.DeleteEmployee(employeeId);
    }

    public async Task<bool> EmployeeExists(int employeeId)
    {
        return await _employeeRepository.EmployeeExists(employeeId);
    }
}