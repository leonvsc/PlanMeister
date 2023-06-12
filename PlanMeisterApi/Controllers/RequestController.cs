using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
    {
        var requests = await _requestService.GetAllRequests();
        if (requests == null) return NotFound();
        return Ok(requests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
        var request = await _requestService.GetRequestById(id);
        if (request == null) return NotFound();
        return Ok(request);
    }

    [HttpGet("ReadByEmployee/{employeeId}")]
    public async Task<ActionResult<IEnumerable<Request>>> ReadByEmployee(int employeeId)
    {
        var requests = await _requestService.GetRequestsByEmployee(employeeId);
        if (requests == null) return NotFound();

        return Ok(requests);
    }

    [HttpPost]
    public async Task<ActionResult<Request>> PostRequest(Request request)
    {
        try
        {
            await _requestService.AddRequest(request);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetRequest), new { id = request.RequestId }, request);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequest(int id, Request request)
    {
        if (id != request.RequestId) return BadRequest();

        try
        {
            await _requestService.UpdateRequest(request);
        }
        catch (Exception ex)
        {
            if (!await _requestService.RequestExists(id))
                return NotFound();
            throw ex;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        var request = await _requestService.GetRequestById(id);
        if (request == null) return NotFound();

        await _requestService.DeleteRequest(request.RequestId);

        return NoContent();
    }
}