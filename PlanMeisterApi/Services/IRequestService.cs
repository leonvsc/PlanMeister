using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IRequestService
{
    Task<Request> GetRequestById(int requestId);
    Task<IEnumerable<Request>> GetAllRequests();
    Task AddRequest(Request request);
    Task UpdateRequest(Request request);
    Task DeleteRequest(int requestId);
    Task<bool> RequestExists(int requestId);
}