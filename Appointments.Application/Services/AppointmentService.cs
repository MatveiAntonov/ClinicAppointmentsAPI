using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Domain.Interfaces.Services;

namespace Appointments.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository repository)
        {
            _appointmentRepository = repository;
        }

        public async Task<IEnumerable<Appointment?>> GetAllAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();

            return appointments;
        }

        public async Task<Appointment?> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointment(id);

            return appointment;
        }

        public async Task<bool> CreateAppointment(Appointment appointment)
        {
            if (appointment is null)
            {
                return false;
            }

            var result = await _appointmentRepository.CreateAppointment(appointment);

            return result;
        }

        public async Task<bool> UpdateAppointment(int id, Appointment appointment)
        {
            if (appointment is null)
            {
                return false;
            }

            Appointment appointmentToUpdate = await _appointmentRepository.GetAppointment(id);

            if (appointmentToUpdate is null)
            {
                return false;
            }

            var result = _appointmentRepository.UpdateAppointment(appointmentToUpdate, appointment);

            return result;
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            Appointment appointment = await _appointmentRepository.GetAppointment(id);
            if (appointment is null)
            {
                return false;
            }

            var result = _appointmentRepository.DeleteAppointment(appointment);

            return result;
        }
    }
}
