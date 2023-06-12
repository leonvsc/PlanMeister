using Microsoft.AspNetCore.Mvc;
using Moq;
using PlanMeisterApi.Controllers;
using PlanMeisterApi.Enum;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterTests;

public class AppointmentControllerTests
{
    [Fact]
    public async Task PostAppointment_ValidData_ReturnsCreatedResult()
    {
        // Arrange
        var mockAppointmentService = new Mock<IAppointmentService>();
        var appointmentData = new Appointment
        {
            Title = "Sample Appointment",
            Description = "This is a test appointment",
            Type = AppointmentType.MorningShift,
            StartDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow.AddHours(1),
            Billable = true,
            DayScheduleId = 1,
            EmployeeId = 1
        };
        var appointmentController = new AppointmentController(mockAppointmentService.Object);

        // Act
        var result = await appointmentController.PostAppointment(appointmentData);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(nameof(AppointmentController.GetAppointment), createdAtActionResult.ActionName);

        // Verify the interaction with the appointment service
        mockAppointmentService.Verify(service => service.AddAppointment(appointmentData), Times.Once);
    }

    [Fact]
    public async Task GetAppointments_ReturnsOkResultWithData()
    {
        // Arrange
        var mockAppointmentService = new Mock<IAppointmentService>();
        var appointmentList = new List<Appointment>
        {
            // Create a sample list of appointments for testing
            new() { AppointmentId = 1, Title = "Appointment 1" },
            new() { AppointmentId = 2, Title = "Appointment 2" },
            new() { AppointmentId = 3, Title = "Appointment 3" }
        };
        mockAppointmentService.Setup(service => service.GetAllAppointments()).ReturnsAsync(appointmentList);
        var appointmentController = new AppointmentController(mockAppointmentService.Object);

        // Act
        var result = await appointmentController.GetAppointments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedAppointments = Assert.IsAssignableFrom<IEnumerable<Appointment>>(okResult.Value);
        Assert.Equal(appointmentList.Count, returnedAppointments.Count());

        // Verify the interaction with the appointment service
        mockAppointmentService.Verify(service => service.GetAllAppointments(), Times.Once);
    }

    [Fact]
    public async Task PutAppointment_ValidData_ReturnsNoContentResult()
    {
        // Arrange
        var mockAppointmentService = new Mock<IAppointmentService>();
        var appointmentData = new Appointment
        {
            AppointmentId = 1,
            Title = "Updated Appointment",
            Description = "Updated description"
            // Provide other updated appointment data for testing
        };
        var appointmentController = new AppointmentController(mockAppointmentService.Object);

        // Act
        var result = await appointmentController.PutAppointment(appointmentData.AppointmentId, appointmentData);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);

        // Verify the interaction with the appointment service
        mockAppointmentService.Verify(service => service.UpdateAppointment(appointmentData), Times.Once);
    }

    [Fact]
    public async Task DeleteAppointment_ExistingAppointment_ReturnsNoContentResult()
    {
        // Arrange
        var mockAppointmentService = new Mock<IAppointmentService>();
        var existingAppointmentId = 1; // Provide an existing appointment ID
        var existingAppointment = new Appointment { AppointmentId = existingAppointmentId };
        mockAppointmentService.Setup(service => service.GetAppointmentById(existingAppointmentId))
            .ReturnsAsync(existingAppointment);
        var appointmentController = new AppointmentController(mockAppointmentService.Object);

        // Act
        var result = await appointmentController.DeleteAppointment(existingAppointmentId);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);

        // Verify the interaction with the appointment service
        mockAppointmentService.Verify(service => service.GetAppointmentById(existingAppointmentId), Times.Once);
        mockAppointmentService.Verify(service => service.DeleteAppointment(existingAppointmentId), Times.Once);
    }

    [Fact]
    public async Task DeleteAppointment_NonExistingAppointment_ReturnsNotFoundResult()
    {
        // Arrange
        var mockAppointmentService = new Mock<IAppointmentService>();
        var nonExistingAppointmentId = 1; // Provide a non-existing appointment ID
        Appointment nullAppointment = null;
        mockAppointmentService.Setup(service => service.GetAppointmentById(nonExistingAppointmentId))
            .ReturnsAsync(nullAppointment);
        var appointmentController = new AppointmentController(mockAppointmentService.Object);

        // Act
        var result = await appointmentController.DeleteAppointment(nonExistingAppointmentId);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);

        // Verify the interaction with the appointment service
        mockAppointmentService.Verify(service => service.GetAppointmentById(nonExistingAppointmentId), Times.Once);
        mockAppointmentService.Verify(service => service.DeleteAppointment(nonExistingAppointmentId), Times.Never);
    }
}