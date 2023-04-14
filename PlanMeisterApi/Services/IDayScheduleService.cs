using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IDayScheduleService
{
    Task<DaySchedule> GetDayScheduleById(int dayId);
    Task<IEnumerable<DaySchedule>> GetAllDaySchedules();
    Task AddDaySchedule(DaySchedule daySchedule);
    Task UpdateDaySchedule(DaySchedule daySchedule);
    Task DeleteDaySchedule(int dayId);
    Task<bool> DayScheduleExists(int dayId);
}