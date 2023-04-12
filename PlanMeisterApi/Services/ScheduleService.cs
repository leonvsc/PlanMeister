using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    
    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<Schedule> GetScheduleById(int scheduleId)
    {
        return await _scheduleRepository.GetScheduleById(scheduleId);
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedules()
    {
        return await _scheduleRepository.GetAllSchedules();
    }

    public async Task AddSchedule(Schedule schedule)
    {
        await _scheduleRepository.AddSchedule(schedule);
    }

    public async Task UpdateSchedule(Schedule schedule)
    {
        if (!await _scheduleRepository.ScheduleExists(schedule.ScheduleId))
        {
            throw new Exception("Schedule not found.");
        }
        await _scheduleRepository.UpdateSchedule(schedule);
    }

    public async Task DeleteSchedule(int scheduleId)
    {
        await _scheduleRepository.DeleteSchedule(scheduleId);
    }

    public async Task<bool> ScheduleExists(int scheduleId)
    {
        return await _scheduleRepository.ScheduleExists(scheduleId);
    }
}