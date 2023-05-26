using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class DayScheduleRepository : IDayScheduleRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public DayScheduleRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<DaySchedule> GetDayScheduleById(int dayScheduleId)
    {
        return await _dbContext.DaySchedules.FindAsync(dayScheduleId);
    }

    public async Task<IEnumerable<DaySchedule>> GetAllDaySchedules()
    {
        return await _dbContext.DaySchedules.ToListAsync();
    }

    public async Task<IEnumerable<DaySchedule>> GetDaySchedulesByWeek(int weekScheduleId)
    {
        return await _dbContext.DaySchedules
            .Where(daySchedule => daySchedule.WeekScheduleId == weekScheduleId)
            .ToListAsync();
    }

    public async Task<IEnumerable<DaySchedule>> GetDayScheduleByDate(DateTime date)
    {
        return await _dbContext.DaySchedules
            .Where(daySchedule => daySchedule.Date.Date == date.Date)
            .ToListAsync();
    }

    public async Task AddDaySchedule(DaySchedule daySchedule)
    {
        await _dbContext.DaySchedules.AddAsync(daySchedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDaySchedule(DaySchedule daySchedule)
    {
        _dbContext.Entry(daySchedule).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDaySchedule(int dayScheduleId)
    {
        var daySchedule = await _dbContext.DaySchedules.FindAsync(dayScheduleId);
        _dbContext.DaySchedules.Remove(daySchedule);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> DayScheduleExists(int dayId)
    {
        return await _dbContext.DaySchedules.AnyAsync(d => d.DayScheduleId == dayId);
    }
}
