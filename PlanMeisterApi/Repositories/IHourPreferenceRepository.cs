using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IHourPreferenceRepository
{
    Task<HourPreference> GetHourPreferenceById(int hourPreferenceId);
    Task<IEnumerable<HourPreference>> GetAllHourPreferences();
    Task AddHourPreference(HourPreference hourPreference);
    Task UpdateHourPreference(HourPreference hourPreference);
    Task DeleteHourPreference(int hourPreferenceId);
    Task<bool> HourPreferenceExists(int hourPreferenceId);
}