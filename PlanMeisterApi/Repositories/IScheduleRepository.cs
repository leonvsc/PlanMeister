using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IScheduleRepository
{
    Task<Schedule> GetScheduleById(int scheduleId);
    Task<IEnumerable<Schedule>> GetAllSchedules();
    Task AddSchedule(Schedule schedule);
    Task UpdateSchedule(Schedule schedule);
    Task DeleteSchedule(int scheduleId);
    Task<bool> ScheduleExists(int scheduleId);
}