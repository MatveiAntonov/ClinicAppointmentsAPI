using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment?>> GetAllAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<bool> CreateAppointment(Appointment appointment);
        Task<bool> UpdateAppointment(int id, Appointment appointment);
        Task<bool> DeleteAppointment(int id);
    }
}
