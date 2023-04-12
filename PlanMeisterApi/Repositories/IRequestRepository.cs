using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IRequestRepository
{
    Task<Request> GetRequestById(int requestId);
    Task<IEnumerable<Request>> GetAllRequests();
    Task AddRequest(Request request);
    Task UpdateRequest(Request request);
    Task DeleteRequest(int requestId);
    Task<bool> RequestExists(int requestId);
}