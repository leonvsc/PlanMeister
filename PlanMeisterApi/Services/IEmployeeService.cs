using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IEmployeeService
{
    Task<Employee> GetEmployeeById(int employeeId);
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
    Task<bool> EmployeeExists(int employeeId);
}