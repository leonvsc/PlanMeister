using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayScheduleController : ControllerBase
    {
        private readonly IDayScheduleService _dayScheduleService;

        public DayScheduleController(IDayScheduleService dayScheduleService)
        {
            _dayScheduleService = dayScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaySchedule>>> GetDaySchedules()
        {
            var daySchedules = await _dayScheduleService.GetAllDaySchedules();
            if (daySchedules == null)
            {
                return NotFound();
            }
            return Ok(daySchedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DaySchedule>> GetDaySchedule(int id)
        {
            var daySchedule = await _dayScheduleService.GetDayScheduleById(id);
            if (daySchedule == null)
            {
                return NotFound();
            }
            return Ok(daySchedule);
        }

        [HttpGet("ReadByWeek/{weekScheduleId:int}")]
        public async Task<ActionResult<IEnumerable<DaySchedule>>> ReadByWeek(int weekScheduleId)
        {
            var daySchedules = await _dayScheduleService.GetDaySchedulesByWeek(weekScheduleId);
            if (daySchedules == null)
            {
                return NotFound();
            }

            return Ok(daySchedules);
        }

        [HttpGet("ReadByDate/{date:datetime}")]
        public async Task<ActionResult<IEnumerable<DaySchedule>>> ReadByDate(DateTime date)
        {
            var daySchedule = await _dayScheduleService.GetDayScheduleByDate(date);
            if (daySchedule == null)
            {
                return NotFound();
            }

            return Ok(daySchedule);
        }

        [HttpPost]
        public async Task<ActionResult<DaySchedule>> PostDaySchedule(DaySchedule daySchedule)
        {
            try
            {
                await _dayScheduleService.AddDaySchedule(daySchedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetDaySchedule), new { id = daySchedule.DayScheduleId }, daySchedule);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDaySchedule(int id, DaySchedule daySchedule)
        {
            if (id != daySchedule.DayScheduleId)
            {
                return BadRequest();
            }

            try
            {
                await _dayScheduleService.UpdateDaySchedule(daySchedule);
            }
            catch (Exception ex)
            {
                if (!await _dayScheduleService.DayScheduleExists(id))
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDaySchedule(int id)
        {
            var day = await _dayScheduleService.GetDayScheduleById(id);
            if (day == null)
            {
                return NotFound();
            }

            await _dayScheduleService.DeleteDaySchedule(day.DayScheduleId);

            return NoContent();
        }
    }
}
