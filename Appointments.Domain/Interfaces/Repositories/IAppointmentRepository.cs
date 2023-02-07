using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment?>> GetAllAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<bool> CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment, Appointment entity);
        bool DeleteAppointment(Appointment appointment);
    }
}
