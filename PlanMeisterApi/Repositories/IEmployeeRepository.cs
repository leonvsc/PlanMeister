using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeById(int employeeId);
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
    Task<bool> EmployeeExists(int employeeId);
}