using System.Net.Http.Json;
using PlanMeisterWeb.Models;

namespace PlanMeisterWeb.Service;

public class DayScheduleService
{
    private readonly HttpClient _httpClient;
    private readonly WeekScheduleService _weekScheduleService;

    public DayScheduleService(HttpClient httpClient, WeekScheduleService weekScheduleService)
    {
        _httpClient = httpClient;
        _weekScheduleService = weekScheduleService;
    }

    public async Task<int> GetDayScheduleIdByDate(DateTime date)
    {
        var formattedDate = date.ToString("yyyy-MM-dd");
        var daySchedule = await _httpClient.GetFromJsonAsync<List<DaySchedule>>($"http://localhost:5175/api/DaySchedule/ReadByDate/{formattedDate}");

        if (daySchedule.Count == 0)
        {
            await CreateDaySchedule(date);
            daySchedule = await _httpClient.GetFromJsonAsync<List<DaySchedule>>($"http://localhost:5175/api/DaySchedule/ReadByDate/{formattedDate}");
        }
    
        var dayScheduleId = daySchedule[0].DayScheduleId;

        return dayScheduleId;
    }

    private async Task CreateDaySchedule(DateTime date)
    {
        var weekScheduleId = await GetWeekScheduleIdByDate(date);
        
        var addDaySchedule = new DaySchedule()
        {
            DayOfWeek = date.DayOfWeek,
            Date = date,
            WeekScheduleId = weekScheduleId,
        };

        var response = await _httpClient.PostAsJsonAsync("api/DaySchedule", addDaySchedule);
        response.EnsureSuccessStatusCode();
    }
    
    private async Task<int> GetWeekScheduleIdByDate(DateTime date)
    {
        return await _weekScheduleService.GetWeekScheduleIdByDate(date);
    }
}