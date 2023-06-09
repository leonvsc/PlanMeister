using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourPreferenceController : ControllerBase
    {
        private readonly IHourPreferenceService _hourPreferenceService;

        public HourPreferenceController(IHourPreferenceService hourPreferenceService)
        {
            _hourPreferenceService = hourPreferenceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourPreference>>> GetHourPreferences()
        {
            var hourPreferences = await _hourPreferenceService.GetAllHourPreferences();
            if (hourPreferences == null)
            {
                return NotFound();
            }
            return Ok(hourPreferences);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HourPreference>> GetHourPreference(int id)
        {
            var hourPreference = await _hourPreferenceService.GetHourPreferenceById(id);
            if (hourPreference == null)
            {
                return NotFound();
            }
            return Ok(hourPreference);
        }

        [HttpPost]
        public async Task<ActionResult<HourPreference>> PostHourPreference(HourPreference hourPreference)
        {
            try
            {
                await _hourPreferenceService.AddHourPreference(hourPreference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetHourPreference), new { id = hourPreference.HourPreferenceId }, hourPreference);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourPreference(int id, HourPreference hourPreference)
        {
            if (id != hourPreference.HourPreferenceId)
            {
                return BadRequest();
            }

            try
            {
                await _hourPreferenceService.UpdateHourPreference(hourPreference);
            }
            catch (Exception ex)
            {
                if (!await _hourPreferenceService.HourPreferenceExists(id))
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
        public async Task<IActionResult> DeleteHourPreference(int id)
        {
            var hourPreference = await _hourPreferenceService.GetHourPreferenceById(id);
            if (hourPreference == null)
            {
                return NotFound();
            }

            await _hourPreferenceService.DeleteHourPreference(hourPreference.HourPreferenceId);

            return NoContent();
        }
    }
}
