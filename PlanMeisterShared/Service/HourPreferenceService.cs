using System.Net;
using System.Net.Http.Json;
using PlanMeisterShared.Enum;
using PlanMeisterShared.Models;

namespace PlanMeisterShared.Service;

public class HourPreferenceService
{
    private readonly HttpClient _httpClient;

    public HourPreferenceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<HourPreference>> GetHourPreferences()
    {
        var response = await _httpClient.GetAsync("/api/HourPreference");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<HourPreference>();
            return await response.Content.ReadFromJsonAsync<IEnumerable<HourPreference>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<HourPreference?> GetHourPreferenceById(int hourPreferenceId)
    {
        return await _httpClient.GetFromJsonAsync<HourPreference>($"/api/HourPreference/{hourPreferenceId}");
    }

    public async Task DeleteHourPreference(int hourPreferenceId)
    {
        await _httpClient.DeleteAsync($"api/HourPreference/{hourPreferenceId}");
    }

    public async Task MarkAsAccepted(int hourPreferenceId)
    {
        var hourPreference = await GetHourPreferenceById(hourPreferenceId);

        if (hourPreference != null)
        {
            var addHourPreference = new HourPreference
            {
                HourPreferenceId = hourPreferenceId,
                WeekNumber = hourPreference.WeekNumber,
                AmountOfHours = hourPreference.AmountOfHours,
                HourPreferenceStatus = HourPreferenceStatus.Accepted,
                EmployeeId = hourPreference.EmployeeId
            };

            await _httpClient.PutAsJsonAsync($"/api/HourPreference/{hourPreferenceId}", addHourPreference);
        }
    }

    public async Task MarkAsDeclined(int hourPreferenceId)
    {
        var hourPreference = await GetHourPreferenceById(hourPreferenceId);

        if (hourPreference != null)
        {
            var addHourPreference = new HourPreference
            {
                HourPreferenceId = hourPreferenceId,
                WeekNumber = hourPreference.WeekNumber,
                AmountOfHours = hourPreference.AmountOfHours,
                HourPreferenceStatus = HourPreferenceStatus.Declined,
                EmployeeId = hourPreference.EmployeeId
            };

            await _httpClient.PutAsJsonAsync($"/api/HourPreference/{hourPreferenceId}", addHourPreference);
        }
    }

    public async Task<IEnumerable<HourPreference>> GetHourPreferencesByEmployee(int employeeId)
    {
        var response = await _httpClient.GetAsync($"/api/HourPreference/ReadByEmployee/{employeeId}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<HourPreference>();
            return await response.Content.ReadFromJsonAsync<IEnumerable<HourPreference>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }
}