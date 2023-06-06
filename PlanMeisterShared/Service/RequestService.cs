using System.Net.Http.Json;
using PlanMeisterShared.Models;

namespace PlanMeisterShared.Service;

public class RequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    public async Task<IEnumerable<Request>> GetRequests()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/Request");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Request>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Request>>();
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
    
    public async Task<Request?> GetRequestById(int requestId)
    {
        return await _httpClient.GetFromJsonAsync<Request>($"/api/Request/{requestId}");
    }

    public async Task DeleteRequest(int requestId)
    {
        await _httpClient.DeleteAsync($"api/Request/{requestId}");
    }
}