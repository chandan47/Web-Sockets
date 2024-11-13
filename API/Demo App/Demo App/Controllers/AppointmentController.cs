using Demo_App.Implementation;
using Demo_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointment;
        public AppointmentController(IAppointmentService appointment)
        {
            _appointment = appointment;
        }


        [HttpGet]
        [Route("/GetAppointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return Ok(await _appointment.GetAppointmentsAsync());
        }

        [HttpGet]
        [Route("/GetAppointmentById/{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment([FromRoute] int id)
        {
            var appointment = await _appointment.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        [HttpPost]
        [Route("/CreateAppointment")]
        public async Task<ActionResult<Order>> CreateAppointment(Appointment appointment)
        {
            var createdAppointment = await _appointment.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = createdAppointment.AppointmentId }, createdAppointment);
        }

        [HttpPut]
        [Route("/UpdateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int id, Appointment appointment)
        {
            var updated = await _appointment.UpdateAppointmentAsync(id, appointment);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("/DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var deleted = await _appointment.DeleteAppointmentAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
