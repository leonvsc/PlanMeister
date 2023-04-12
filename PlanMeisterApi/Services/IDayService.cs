using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IDayService
{
    Task<Day> GetDayById(int dayId);
    Task<IEnumerable<Day>> GetAllDays();
    Task AddDay(Day day);
    Task UpdateDay(Day day);
    Task DeleteDay(int dayId);
    Task<bool> DayExists(int dayId);
}