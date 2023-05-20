using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class WeekScheduleService : IWeekScheduleService
{
    private readonly IWeekScheduleRepository _weekScheduleRepository;
    
    public WeekScheduleService(IWeekScheduleRepository weekScheduleRepository)
    {
        _weekScheduleRepository = weekScheduleRepository;
    }

    public async Task<WeekSchedule> GetWeekScheduleById(int WeekScheduleId)
    {
        return await _weekScheduleRepository.GetWeekScheduleById(WeekScheduleId);
    }

    public async Task<IEnumerable<WeekSchedule>> GetAllWeekSchedules()
    {
        return await _weekScheduleRepository.GetAllWeekSchedules();
    }

    public async Task<IEnumerable<WeekSchedule>> GetWeekScheduleByWeek(int weekNumber)
    {
        return await _weekScheduleRepository.GetWeekScheduleByWeek(weekNumber);
    }

    public async Task AddWeekSchedule(WeekSchedule weekSchedule)
    {
        await _weekScheduleRepository.AddWeekSchedule(weekSchedule);
    }

    public async Task UpdateWeekSchedule(WeekSchedule weekSchedule)
    {
        if (!await _weekScheduleRepository.WeekScheduleExists(weekSchedule.WeekScheduleId))
        {
            throw new Exception("Schedule not found.");
        }
        await _weekScheduleRepository.UpdateWeekSchedule(weekSchedule);
    }

    public async Task DeleteWeekSchedule(int WeekScheduleId)
    {
        await _weekScheduleRepository.DeleteWeekSchedule(WeekScheduleId);
    }

    public async Task<bool> WeekScheduleExists(int WeekScheduleId)
    {
        return await _weekScheduleRepository.WeekScheduleExists(WeekScheduleId);
    }
}