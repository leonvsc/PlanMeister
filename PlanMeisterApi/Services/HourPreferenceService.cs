using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class HourPreferenceService : IHourPreferenceService
{
    private readonly IHourPreferenceRepository _hourPreferenceRepository;

    public HourPreferenceService(IHourPreferenceRepository hourPreferenceRepository)
    {
        _hourPreferenceRepository = hourPreferenceRepository;
    }
    
    public async Task<HourPreference> GetHourPreferenceById(int hourPreferenceId)
    {
        return await _hourPreferenceRepository.GetHourPreferenceById(hourPreferenceId);
    }

    public async Task<IEnumerable<HourPreference>> GetAllHourPreferences()
    {
        return await _hourPreferenceRepository.GetAllHourPreferences();
    }

    public async Task AddHourPreference(HourPreference hourPreference)
    {
        await _hourPreferenceRepository.AddHourPreference(hourPreference);
    }

    public async Task UpdateHourPreference(HourPreference hourPreference)
    {
        if (!await _hourPreferenceRepository.HourPreferenceExists(hourPreference.HourPreferenceId))
        {
            throw new Exception("Hour preference not found.");
        }
        await _hourPreferenceRepository.UpdateHourPreference(hourPreference);
    }

    public async Task DeleteHourPreference(int hourPreferenceId)
    {
        await _hourPreferenceRepository.DeleteHourPreference(hourPreferenceId);
    }

    public async Task<bool> HourPreferenceExists(int hourPreferenceId)
    {
        return await _hourPreferenceRepository.HourPreferenceExists(hourPreferenceId);
    }
}