using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IHourPreferenceService
{
    Task<HourPreference> GetHourPreferenceById(int hourPreferenceId);
    Task<IEnumerable<HourPreference>> GetAllHourPreferences();
    Task AddHourPreference(HourPreference hourPreference);
    Task UpdateHourPreference(HourPreference hourPreference);
    Task DeleteHourPreference(int hourPreferenceId);
    Task<bool> HourPreferenceExists(int hourPreferenceId);
}