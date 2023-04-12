using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class DayService : IDayService
{
    private readonly IDayRepository _dayRepository;

    public DayService(IDayRepository dayRepository)
    {
        _dayRepository = dayRepository;
    }
    
    public async Task<Day> GetDayById(int dayId)
    {
        return await _dayRepository.GetDayById(dayId);
    }

    public async Task<IEnumerable<Day>> GetAllDays()
    {
        return await _dayRepository.GetAllDays();
    }

    public async Task AddDay(Day day)
    {
        await _dayRepository.AddDay(day);
    }

    public async Task UpdateDay(Day day)
    {
        if (!await _dayRepository.DayExists(day.DayId))
        {
            throw new Exception("Day not found.");
        }
        await _dayRepository.UpdateDay(day);
    }

    public async Task DeleteDay(int dayId)
    {
        await _dayRepository.DeleteDay(dayId);
    }
    
    public async Task<bool> DayExists(int dayId)
    {
        return await _dayRepository.DayExists(dayId);
    }

}