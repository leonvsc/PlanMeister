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
}