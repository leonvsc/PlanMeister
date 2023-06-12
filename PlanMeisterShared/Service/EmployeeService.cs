using System.Net;
using System.Net.Http.Json;
using PlanMeisterShared.Models;

namespace PlanMeisterShared.Service;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        var response = await _httpClient.GetAsync("/api/Employee");

        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NoContent) return Enumerable.Empty<Employee>();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Employee>>();
        }

        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{employeeId}");
    }
}