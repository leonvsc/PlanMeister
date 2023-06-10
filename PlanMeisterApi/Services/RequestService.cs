using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class RequestService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    
    public RequestService(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<Request> GetRequestById(int requestId)
    {
        return await _requestRepository.GetRequestById(requestId);
    }

    public async Task<IEnumerable<Request>> GetAllRequests()
    {
        return await _requestRepository.GetAllRequests();
    }

    public async Task<IEnumerable<Request>> GetRequestsByEmployee(int employeeId)
    {
        return await _requestRepository.GetRequestsByEmployee(employeeId);
    }

    public async Task AddRequest(Request request)
    {
        await _requestRepository.AddRequest(request);
    }

    public async Task UpdateRequest(Request request)
    {
        if (!await _requestRepository.RequestExists(request.RequestId))
        {
            throw new Exception("Request not found.");
        }
        await _requestRepository.UpdateRequest(request);
    }

    public async Task DeleteRequest(int requestId)
    {
        await _requestRepository.DeleteRequest(requestId);
    }

    public async Task<bool> RequestExists(int requestId)
    {
        return await _requestRepository.RequestExists(requestId);
    }

}