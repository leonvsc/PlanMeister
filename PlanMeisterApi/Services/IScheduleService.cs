using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IScheduleService
{
    Task<Schedule> GetScheduleById(int scheduleId);
    Task<IEnumerable<Schedule>> GetAllSchedules();
    Task AddSchedule(Schedule schedule);
    Task UpdateSchedule(Schedule schedule);
    Task DeleteSchedule(int scheduleId);
    Task<bool> ScheduleExists(int scheduleId);
}