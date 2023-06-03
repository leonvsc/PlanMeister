using System.Globalization;
using System.Net.Http.Json;
using PlanMeisterShared.Models;

namespace PlanMeisterShared.Service;

public class WeekScheduleService
{
    private readonly HttpClient _httpClient;

    public WeekScheduleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private int GetIso8601WeekOfYear(DateTime date)
    {
        var cal = CultureInfo.CurrentCulture.Calendar;
        var weekOfYear = cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        return weekOfYear;
    }
    
    public async Task<int> GetWeekScheduleIdByDate(DateTime date)
    {
        var weekNumber = GetIso8601WeekOfYear(date.Date);

        var weekSchedule =
            await _httpClient.GetFromJsonAsync<List<WeekSchedule>>($"api/WeekSchedule/ReadByWeekNumber/{weekNumber}");

        if (weekSchedule.Count == 0)
        {
            await CreateWeekSchedule(weekNumber);
            weekSchedule =
                await _httpClient.GetFromJsonAsync<List<WeekSchedule>>($"api/WeekSchedule/ReadByWeekNumber/{weekNumber}");
        }

        var weekScheduleId = weekSchedule[0].WeekScheduleId;

        return weekScheduleId;
    }

    private async Task CreateWeekSchedule(int weekNumber)
    {
        var addWeekSchedule = new WeekSchedule()
        {
            WeekNumber = weekNumber
        };
        
        var response = await _httpClient.PostAsJsonAsync("/api/WeekSchedule", addWeekSchedule);
        response.EnsureSuccessStatusCode();
    }
}