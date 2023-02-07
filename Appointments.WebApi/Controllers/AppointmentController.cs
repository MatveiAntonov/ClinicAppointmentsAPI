using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Services;
using Appointments.WebApi.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Profiles.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            if (appointments.Count() != 0)
            {
                var appointmentsDto = new List<AppointmentDto>();
                foreach (var appointment in appointments)
                {
                    appointmentsDto.Add(_mapper.Map<AppointmentDto>(appointment));
                }
                return Ok(appointments);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            if (appointment is not null)
            {
                var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
                return Ok(appointmentDto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromForm] AppointmentDto entity)
        {
            if (entity == null)
                return BadRequest();

            var appointment = _mapper.Map<Appointment>(entity);

            var result = await _appointmentService.CreateAppointment(appointment);
            if (result != false)
            {
                return Created($"/appointment/{entity.Id}", entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, [FromForm] AppointmentDto entity)
        {
            if (entity == null)
                return BadRequest();

            var appointmentToUpdate = await _appointmentService.GetAppointment(id);
            if (appointmentToUpdate is null)
            {
                return NotFound();
            }

            var appointment = _mapper.Map<Appointment>(entity);

            var result = await _appointmentService.UpdateAppointment(id, appointment);
            if (result != false)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            if (await _appointmentService.GetAppointment(id) is null)
            {
                return BadRequest();
            };

            var result = await _appointmentService.DeleteAppointment(id);
            if (result != false)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
