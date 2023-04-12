using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly PlanMeisterDbContext _dbContext;
    
    public RequestRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Request> GetRequestById(int requestId)
    {
        return await _dbContext.Requests.FindAsync(requestId);
    }

    public async Task<IEnumerable<Request>> GetAllRequests()
    {
        return await _dbContext.Requests.ToListAsync();
    }

    public async Task AddRequest(Request request)
    {
        await _dbContext.Requests.AddAsync(request);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRequest(Request request)
    {
        _dbContext.Entry(request).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRequest(int requestId)
    {
        var request = await _dbContext.Requests.FindAsync(requestId);
        _dbContext.Requests.Remove(request);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> RequestExists(int requestId)
    {
        return await _dbContext.Requests.AnyAsync(r => r.RequestId == requestId);
    }

}