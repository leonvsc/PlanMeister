using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class WeekScheduleRepository : IWeekScheduleRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public WeekScheduleRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WeekSchedule> GetWeekScheduleById(int scheduleId)
    {
        return await _dbContext.WeekSchedules.FindAsync(scheduleId);
    }

    public async Task<IEnumerable<WeekSchedule>> GetAllWeekSchedules()
    {
        return await _dbContext.WeekSchedules.ToListAsync();
    }

    public async Task<IEnumerable<WeekSchedule>> GetWeekScheduleByWeek(int weekNumber)
    {
        return await _dbContext.WeekSchedules
            .Where(weekSchedule => weekSchedule.WeekNumber == weekNumber)
            .ToListAsync();
    }

    public async Task AddWeekSchedule(WeekSchedule weekSchedule)
    {
        await _dbContext.WeekSchedules.AddAsync(weekSchedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateWeekSchedule(WeekSchedule weekSchedule)
    {
        _dbContext.Entry(weekSchedule).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteWeekSchedule(int WeekScheduleId)
    {
        var weekSchedule = await _dbContext.WeekSchedules.FindAsync(WeekScheduleId);
        _dbContext.WeekSchedules.Remove(weekSchedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> WeekScheduleExists(int WeekScheduleId)
    {
        return await _dbContext.WeekSchedules.AnyAsync(s => s.WeekScheduleId == WeekScheduleId);
    }
}