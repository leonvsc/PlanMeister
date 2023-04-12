using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IDayRepository
{
    Task<Day> GetDayById(int dayId);
    Task<IEnumerable<Day>> GetAllDays();
    Task AddDay(Day day);
    Task UpdateDay(Day day);
    Task DeleteDay(int dayId);
    Task<bool> DayExists(int dayId);
}
