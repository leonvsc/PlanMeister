using Microsoft.AspNetCore.Mvc;
using PlanMeisterApi.Models;
using PlanMeisterApi.Services;

namespace PlanMeisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            if (appointments == null)
            {
                return NotFound();
            }
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet("ReadByDay/{dayScheduleId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> ReadByDay(int dayScheduleId)
        {
            var appointments = await _appointmentService.GetAppointmentsByDay(dayScheduleId);
            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }
        
        [HttpGet("ReadByEmployee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> ReadByEmployee(int employeeId)
        {
            var appointments = await _appointmentService.GetAppointmentsByEmployee(employeeId);
            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            try
            {
                await _appointmentService.AddAppointment(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            try
            {
                await _appointmentService.UpdateAppointment(appointment);
            }
            catch (Exception ex)
            {
                if (!await _appointmentService.AppointmentExists(id))
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
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentService.DeleteAppointment(appointment.AppointmentId);

            return NoContent();
        }
    }
}
