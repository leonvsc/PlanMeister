using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly PlanMeisterDbContext _dbContext;
    
    public ScheduleRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Schedule> GetScheduleById(int scheduleId)
    {
        return await _dbContext.Schedules.FindAsync(scheduleId);
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedules()
    {
        return await _dbContext.Schedules.ToListAsync();
    }

    public async Task AddSchedule(Schedule schedule)
    {
        await _dbContext.Schedules.AddAsync(schedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSchedule(Schedule schedule)
    {
        _dbContext.Entry(schedule).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteSchedule(int scheduleId)
    {
        var schedule = await _dbContext.Schedules.FindAsync(scheduleId);
        _dbContext.Schedules.Remove(schedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ScheduleExists(int scheduleId)
    {
        return await _dbContext.Schedules.AnyAsync(s => s.ScheduleId == scheduleId);
    }
}