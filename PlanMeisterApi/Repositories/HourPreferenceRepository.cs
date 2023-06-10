using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class HourPreferenceRepository : IHourPreferenceRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public HourPreferenceRepository(PlanMeisterDbContext planMeisterDbContext)
    {
        _dbContext = planMeisterDbContext;
    }
    
    public async Task<HourPreference> GetHourPreferenceById(int hourPreferenceId)
    {
        return await _dbContext.HourPreferences.FindAsync(hourPreferenceId);
    }

    public async Task<IEnumerable<HourPreference>> GetAllHourPreferences()
    {
        return await _dbContext.HourPreferences.ToListAsync();
    }
    
    public async Task<IEnumerable<HourPreference>> GetHourPreferencesByEmployee(int employeeId)
    {
        return await _dbContext.HourPreferences
            .Where(hourPreference => hourPreference.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task AddHourPreference(HourPreference hourPreference)
    {
        await _dbContext.HourPreferences.AddAsync(hourPreference);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateHourPreference(HourPreference hourPreference)
    {
        _dbContext.Entry(hourPreference).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteHourPreference(int hourPreferenceId)
    {
        var hourPreference = await _dbContext.HourPreferences.FindAsync(hourPreferenceId);
        _dbContext.HourPreferences.Remove(hourPreference);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> HourPreferenceExists(int hourPreferenceId)
    {
        return await _dbContext.HourPreferences.AnyAsync(hp => hp.HourPreferenceId == hourPreferenceId);
    }
}