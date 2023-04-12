using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IDayService _dayService;

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            var days = await _dayService.GetAllDays();
            if (days == null)
            {
                return NotFound();
            }
            return Ok(days);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _dayService.GetDayById(id);
            if (day == null)
            {
                return NotFound();
            }
            return Ok(day);
        }

        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            try
            {
                await _dayService.AddDay(day);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetDay), new { id = day.DayId }, day);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(int id, Day day)
        {
            if (id != day.DayId)
            {
                return BadRequest();
            }

            try
            {
                await _dayService.UpdateDay(day);
            }
            catch (Exception ex)
            {
                if (!await _dayService.DayExists(id))
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
        public async Task<IActionResult> DeleteDay(int id)
        {
            var day = await _dayService.GetDayById(id);
            if (day == null)
            {
                return NotFound();
            }

            await _dayService.DeleteDay(day.DayId);

            return NoContent();
        }
    }
}
