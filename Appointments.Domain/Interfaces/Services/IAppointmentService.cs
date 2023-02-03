using Appointments.Domain.Entities;

namespace Profiles.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment?>> GetAllAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<Appointment?> CreateAppointment(Appointment appointment);
        Task<Appointment?> UpdateAppointment(Appointment appointment);
        Task<Appointment?> DeleteAppointment(int id);
    }
}
