using System.Net;
using System.Net.Http.Json;
using PlanMeisterShared.Models;

namespace PlanMeisterShared.Service;

public class AppointmentService
{
    private readonly HttpClient _httpClient;

    public AppointmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Appointment>> GetAppointments()
    {
        var response = await _httpClient.GetAsync("/api/Appointment");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<Appointment>();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<List<Appointment>> GetAppointmentsByWeek(int weekNumber)
    {
        try
        {
            var weekSchedules =
                await _httpClient.GetFromJsonAsync<List<WeekSchedule>>(
                    $"/api/WeekSchedule/ReadByWeekNumber/{weekNumber}");
            var weekSchedule = weekSchedules.FirstOrDefault();
            var weekScheduleId = weekSchedule?.WeekScheduleId;

            var daySchedules =
                await _httpClient.GetFromJsonAsync<List<DaySchedule>>($"/api/DaySchedule/ReadByWeek/{weekScheduleId}");
            var dayScheduleIds = daySchedules.Select(d => d.DayScheduleId).ToList();

            var appointments = new List<Appointment>();
            foreach (var dayScheduleId in dayScheduleIds)
            {
                var appointmentsByDay =
                    await _httpClient.GetFromJsonAsync<List<Appointment>>(
                        $"/api/Appointment/ReadByDay/{dayScheduleId}");
                appointments.AddRange(appointmentsByDay);
            }

            return appointments;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load appointments: {ex.Message}");
            return new List<Appointment>();
        }
    }

    public async Task<Appointment?> GetAppointmentById(int appointmentId)
    {
        return await _httpClient.GetFromJsonAsync<Appointment>($"api/Appointment/{appointmentId}");
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        await _httpClient.DeleteAsync($"api/Appointment/{appointmentId}");
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByEmployee(int employeeId)
    {
        var response = await _httpClient.GetAsync($"/api/Appointment/ReadByEmployee/{employeeId}");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<Appointment>();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Appointment>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }
}