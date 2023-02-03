

using Appointments.Domain.Entities;
using Profiles.Domain.Interfaces.Repositories;

namespace Profiles.Application.Services
{
    public class AppointmentService : IAppointmentRepository
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

        public async Task<Appointment?> CreateAppointment(Appointment appointment)
        {
            var createdAppointment = await _appointmentRepository.CreateAppointment(appointment);

            return createdAppointment;
        }

        public async Task<Appointment?> UpdateAppointment(Appointment appointment)
        {
            var updatedAppointment = await _appointmentRepository.UpdateAppointment(appointment);

            return updatedAppointment;
        }
        public async Task<Appointment?> DeleteAppointment(int id)
        {
            var deletedAppointment = await _appointmentRepository.DeleteAppointment(id);

            return deletedAppointment;
        }
    }
}
