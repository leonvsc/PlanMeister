using Microsoft.AspNetCore.Mvc;
using Moq;
using PlanMeisterApi.Controllers;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterTests;

public class EmployeeControllerTests
{
    [Fact]
        public async Task GetEmployees_ReturnsEmployees()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1 },
                new Employee { EmployeeId = 2 }
            };
            mockEmployeeService.Setup(service => service.GetAllEmployees()).ReturnsAsync(employees);
            var employeeController = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = await employeeController.GetEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployees = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);
            Assert.Equal(employees, returnedEmployees);

            // Verify the interaction with the employee service
            mockEmployeeService.Verify(service => service.GetAllEmployees(), Times.Once);
        }

        [Fact]
        public async Task PostEmployee_ValidEmployee_ReturnsCreatedResult()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            var employee = new Employee { EmployeeId = 1 }; // Provide a valid employee object
            var employeeController = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = await employeeController.PostEmployee(employee);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(EmployeeController.GetEmployee), createdAtActionResult.ActionName);

            // Verify the interaction with the employee service
            mockEmployeeService.Verify(service => service.AddEmployee(employee), Times.Once);
        }
        
        [Fact]
        public async Task GetEmployee_ValidId_ReturnsEmployee()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            var employeeId = 1;
            var expectedEmployee = new Employee { EmployeeId = employeeId, Name = "John Doe" };
            mockEmployeeService.Setup(service => service.GetEmployeeById(employeeId))
                .ReturnsAsync(expectedEmployee);
            var employeeController = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = await employeeController.GetEmployee(employeeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var employee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(expectedEmployee, employee);
        }
}