using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class DayRepository : IDayRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public DayRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Day> GetDayById(int dayId)
    {
        return await _dbContext.Days.FindAsync(dayId);
    }

    public async Task<IEnumerable<Day>> GetAllDays()
    {
        return await _dbContext.Days.ToListAsync();
    }

    public async Task AddDay(Day day)
    {
        await _dbContext.Days.AddAsync(day);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDay(Day day)
    {
        _dbContext.Entry(day).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDay(int dayId)
    {
        var day = await _dbContext.Days.FindAsync(dayId);
        _dbContext.Days.Remove(day);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> DayExists(int dayId)
    {
        return await _dbContext.Days.AnyAsync(d => d.DayId == dayId);
    }
}
