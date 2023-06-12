using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public EmployeeRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _dbContext.Employees.FindAsync(employeeId);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task AddEmployee(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateEmployee(Employee employee)
    {
        _dbContext.Entry(employee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var employee = await _dbContext.Employees.FindAsync(employeeId);
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> EmployeeExists(int employeeId)
    {
        return await _dbContext.Employees.AnyAsync(e => e.EmployeeId == employeeId);
    }
}