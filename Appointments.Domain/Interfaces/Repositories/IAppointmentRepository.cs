using Appointments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Domain.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment?>> GetAllAppointments();
        Task<Appointment?> GetAppointment(int id);
        Task<Appointment?> CreateAppointment(Appointment appointment);
        Task<Appointment?> UpdateAppointment(Appointment appointment);
        Task<Appointment?> DeleteAppointment(int id);
    }
}
