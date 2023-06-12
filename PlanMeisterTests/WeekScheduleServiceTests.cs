using Moq;
using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;
using PlanMeisterApi.Services;

namespace PlanMeisterTests;

public class WeekScheduleServiceTests
{
    [Fact]
        public async Task GetWeekScheduleById_ExistingWeekScheduleId_ReturnsWeekSchedule()
        {
            // Arrange
            var mockWeekScheduleRepository = new Mock<IWeekScheduleRepository>();
            var weekScheduleId = 1;
            var expectedWeekSchedule = new WeekSchedule { WeekScheduleId = weekScheduleId };
            mockWeekScheduleRepository.Setup(repo => repo.GetWeekScheduleById(weekScheduleId)).ReturnsAsync(expectedWeekSchedule);
            var weekScheduleService = new WeekScheduleService(mockWeekScheduleRepository.Object);

            // Act
            var result = await weekScheduleService.GetWeekScheduleById(weekScheduleId);

            // Assert
            Assert.Equal(expectedWeekSchedule, result);

            // Verify the interaction with the week schedule repository
            mockWeekScheduleRepository.Verify(repo => repo.GetWeekScheduleById(weekScheduleId), Times.Once);
        }

        [Fact]
        public async Task GetAllWeekSchedules_ReturnsWeekSchedules()
        {
            // Arrange
            var mockWeekScheduleRepository = new Mock<IWeekScheduleRepository>();
            var weekSchedules = new List<WeekSchedule>
            {
                new WeekSchedule { WeekScheduleId = 1 },
                new WeekSchedule { WeekScheduleId = 2 }
            };
            mockWeekScheduleRepository.Setup(repo => repo.GetAllWeekSchedules()).ReturnsAsync(weekSchedules);
            var weekScheduleService = new WeekScheduleService(mockWeekScheduleRepository.Object);

            // Act
            var result = await weekScheduleService.GetAllWeekSchedules();

            // Assert
            Assert.Equal(weekSchedules, result);

            // Verify the interaction with the week schedule repository
            mockWeekScheduleRepository.Verify(repo => repo.GetAllWeekSchedules(), Times.Once);
        }

        [Fact]
        public async Task AddWeekSchedule_ValidWeekSchedule_CallsAddWeekScheduleInRepository()
        {
            // Arrange
            var mockWeekScheduleRepository = new Mock<IWeekScheduleRepository>();
            var weekSchedule = new WeekSchedule { WeekScheduleId = 1 }; // Provide a valid week schedule object
            var weekScheduleService = new WeekScheduleService(mockWeekScheduleRepository.Object);

            // Act
            await weekScheduleService.AddWeekSchedule(weekSchedule);

            // Assert
            mockWeekScheduleRepository.Verify(repo => repo.AddWeekSchedule(weekSchedule), Times.Once);
        }
}