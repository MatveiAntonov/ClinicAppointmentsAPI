using Appointments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Persistence.Contexts;

namespace Appointments.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentsDbContext _appointmentsDbContext;

        public AppointmentRepository(AppointmentsDbContext appointmentsDbContext)
        {
            _appointmentsDbContext = appointmentsDbContext;
        }
        public async Task<IEnumerable<Appointment?>> GetAllAppointments()
        {
            return await _appointmentsDbContext.Appointments.ToListAsync();
        }
        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _appointmentsDbContext.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> CreateAppointment(Appointment appointment)
        {
            try
            {
                await _appointmentsDbContext.Appointments.AddAsync(appointment);
                _appointmentsDbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAppointment(Appointment appointment, Appointment entity)
        {
            try
            {
                appointment.PatientId = entity.PatientId;
                appointment.DoctorId = entity.DoctorId;
                appointment.ServiceId = entity.ServiceId;
                appointment.DateTime = entity.DateTime;
                appointment.IsApproved = entity.IsApproved;

                _appointmentsDbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            try
            {
                _appointmentsDbContext.Appointments.Remove(appointment);
                _appointmentsDbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
