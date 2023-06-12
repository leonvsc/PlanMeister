using Moq;
using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;
using PlanMeisterApi.Services;

namespace PlanMeisterTests;

public class EmployeeServiceTests
{
    [Fact]
    public async Task GetEmployeeById_ExistingEmployeeId_ReturnsEmployee()
    {
        // Arrange
        var mockEmployeeRepository = new Mock<IEmployeeRepository>();
        var employeeId = 1; // Provide an existing employee ID
        var expectedEmployee = new Employee { EmployeeId = employeeId };
        mockEmployeeRepository.Setup(repo => repo.GetEmployeeById(employeeId)).ReturnsAsync(expectedEmployee);
        var employeeService = new EmployeeService(mockEmployeeRepository.Object);

        // Act
        var result = await employeeService.GetEmployeeById(employeeId);

        // Assert
        Assert.Equal(expectedEmployee, result);
        // Add more assertions based on your specific requirements

        // Verify the interaction with the employee repository
        mockEmployeeRepository.Verify(repo => repo.GetEmployeeById(employeeId), Times.Once);
    }

    [Fact]
    public async Task GetAllEmployees_ReturnsEmployees()
    {
        // Arrange
        var mockEmployeeRepository = new Mock<IEmployeeRepository>();
        var employees = new List<Employee>
        {
            new Employee { EmployeeId = 1 },
            new Employee { EmployeeId = 2 }
        };
        mockEmployeeRepository.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(employees);
        var employeeService = new EmployeeService(mockEmployeeRepository.Object);

        // Act
        var result = await employeeService.GetAllEmployees();

        // Assert
        Assert.Equal(employees, result);
        // Add more assertions based on your specific requirements

        // Verify the interaction with the employee repository
        mockEmployeeRepository.Verify(repo => repo.GetAllEmployees(), Times.Once);
    }

    [Fact]
    public async Task AddEmployee_ValidEmployee_CallsAddEmployeeInRepository()
    {
        // Arrange
        var mockEmployeeRepository = new Mock<IEmployeeRepository>();
        var employee = new Employee { EmployeeId = 1 }; // Provide a valid employee object
        var employeeService = new EmployeeService(mockEmployeeRepository.Object);

        // Act
        await employeeService.AddEmployee(employee);

        // Assert
        mockEmployeeRepository.Verify(repo => repo.AddEmployee(employee), Times.Once);
    }
}