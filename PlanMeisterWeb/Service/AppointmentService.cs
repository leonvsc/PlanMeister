using System.Net.Http.Json;
using PlanMeisterWeb.Models;

namespace PlanMeisterWeb.Service;

public class AppointmentService
{
    private readonly HttpClient _httpClient;

    public AppointmentService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    public async Task<IEnumerable<AppointmentModel>> GetAppointments()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/Appointment");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<AppointmentModel>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<AppointmentModel>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}