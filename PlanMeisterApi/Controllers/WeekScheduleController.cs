using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeekScheduleController : ControllerBase
{
    private readonly IWeekScheduleService _weekScheduleService;

    public WeekScheduleController(IWeekScheduleService weekScheduleService)
    {
        _weekScheduleService = weekScheduleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeekSchedule>>> GetWeekSchedules()
    {
        var weekSchedules = await _weekScheduleService.GetAllWeekSchedules();
        if (weekSchedules == null) return NotFound();
        return Ok(weekSchedules);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WeekSchedule>> GetWeekSchedule(int id)
    {
        var weekSchedule = await _weekScheduleService.GetWeekScheduleById(id);
        if (weekSchedule == null) return NotFound();
        return Ok(weekSchedule);
    }

    [HttpGet("ReadByWeekNumber/{weekNumber:int}")]
    public async Task<ActionResult<IEnumerable<WeekSchedule>>> ReadByWeekNumber(int weekNumber)
    {
        var weekSchedule = await _weekScheduleService.GetWeekScheduleByWeek(weekNumber);
        if (weekSchedule == null) return NotFound();

        return Ok(weekSchedule);
    }

    [HttpPost]
    public async Task<ActionResult<WeekSchedule>> PostWeekSchedule(WeekSchedule weekSchedule)
    {
        try
        {
            await _weekScheduleService.AddWeekSchedule(weekSchedule);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetWeekSchedule), new { id = weekSchedule.WeekScheduleId }, weekSchedule);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutWeekSchedule(int id, WeekSchedule weekSchedule)
    {
        if (id != weekSchedule.WeekScheduleId) return BadRequest();

        try
        {
            await _weekScheduleService.UpdateWeekSchedule(weekSchedule);
        }
        catch (Exception ex)
        {
            if (!await _weekScheduleService.WeekScheduleExists(id))
                return NotFound();
            throw ex;
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteWeekSchedule(int id)
    {
        var weekSchedule = await _weekScheduleService.GetWeekScheduleById(id);
        if (weekSchedule == null) return NotFound();

        await _weekScheduleService.DeleteWeekSchedule(weekSchedule.WeekScheduleId);

        return NoContent();
    }
}