using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers
{
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
            var WeekSchedules = await _weekScheduleService.GetAllWeekSchedules();
            if (WeekSchedules == null)
            {
                return NotFound();
            }
            return Ok(WeekSchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeekSchedule>> GetWeekSchedule(int id)
        {
            var WeekSchedule = await _weekScheduleService.GetWeekScheduleById(id);
            if (WeekSchedule == null)
            {
                return NotFound();
            }
            return Ok(WeekSchedule);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeekSchedule(int id, WeekSchedule weekSchedule)
        {
            if (id != weekSchedule.WeekScheduleId)
            {
                return BadRequest();
            }

            try
            {
                await _weekScheduleService.UpdateWeekSchedule(weekSchedule);
            }
            catch (Exception ex)
            {
                if (!await _weekScheduleService.WeekScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekSchedule(int id)
        {
            var WeekSchedule = await _weekScheduleService.GetWeekScheduleById(id);
            if (WeekSchedule == null)
            {
                return NotFound();
            }

            await _weekScheduleService.DeleteWeekSchedule(WeekSchedule.WeekScheduleId);

            return NoContent();
        }
    }
}
