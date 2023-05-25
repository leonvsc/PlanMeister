using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class DayScheduleService : IDayScheduleService
{
    private readonly IDayScheduleRepository _dayScheduleRepository;

    public DayScheduleService(IDayScheduleRepository dayScheduleRepository)
    {
        _dayScheduleRepository = dayScheduleRepository;
    }
    
    public async Task<DaySchedule> GetDayScheduleById(int dayId)
    {
        return await _dayScheduleRepository.GetDayScheduleById(dayId);
    }

    public async Task<IEnumerable<DaySchedule>> GetAllDaySchedules()
    {
        return await _dayScheduleRepository.GetAllDaySchedules();
    }

    public async Task<IEnumerable<DaySchedule>> GetDaySchedulesByWeek(int weekScheduleId)
    {
        return await _dayScheduleRepository.GetDaySchedulesByWeek(weekScheduleId);
    }

    public async Task<IEnumerable<DaySchedule>> GetDayScheduleByDate(DateTime date)
    {
        return await _dayScheduleRepository.GetDayScheduleByDate(date);
    }

    public async Task AddDaySchedule(DaySchedule daySchedule)
    {
        await _dayScheduleRepository.AddDaySchedule(daySchedule);
    }

    public async Task UpdateDaySchedule(DaySchedule daySchedule)
    {
        if (!await _dayScheduleRepository.DayScheduleExists(daySchedule.DayScheduleId))
        {
            throw new Exception("Day not found.");
        }
        await _dayScheduleRepository.UpdateDaySchedule(daySchedule);
    }

    public async Task DeleteDaySchedule(int dayId)
    {
        await _dayScheduleRepository.DeleteDaySchedule(dayId);
    }
    
    public async Task<bool> DayScheduleExists(int dayId)
    {
        return await _dayScheduleRepository.DayScheduleExists(dayId);
    }

}