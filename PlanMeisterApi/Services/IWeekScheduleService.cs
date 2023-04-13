using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IWeekScheduleService
{
    Task<WeekSchedule> GetWeekScheduleById(int WeekScheduleId);
    Task<IEnumerable<WeekSchedule>> GetAllWeekSchedules();
    Task AddWeekSchedule(WeekSchedule weekSchedule);
    Task UpdateWeekSchedule(WeekSchedule weekSchedule);
    Task DeleteWeekSchedule(int WeekScheduleId);
    Task<bool> WeekScheduleExists(int WeekScheduleId);
}