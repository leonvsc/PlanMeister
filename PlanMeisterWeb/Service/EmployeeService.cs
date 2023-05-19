using System.Net.Http.Json;
using PlanMeisterWeb.Models;

namespace PlanMeisterWeb.Service;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/Employee");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Employee>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Employee>>();
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