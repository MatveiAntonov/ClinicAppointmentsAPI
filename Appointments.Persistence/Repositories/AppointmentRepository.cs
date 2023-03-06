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
            return await _appointmentsDbContext.Appointments
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Service)
                .ToListAsync();
        }
        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _appointmentsDbContext.Appointments
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Service)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> CreateAppointment(Appointment appointment)
        {
            try
            {
                var doctor = _appointmentsDbContext.Doctors
                    .FirstOrDefault(doctor => doctor.Id == appointment.DoctorId);

                var patient = _appointmentsDbContext.Patients
                    .FirstOrDefault(patient => patient.Id == appointment.PatientId);

                var service = _appointmentsDbContext.Services
                    .FirstOrDefault(service => service.Id == appointment.ServiceId);

                if (doctor is not null & patient is not null & service is not null)
                {
                    appointment.Doctor = doctor;
                    appointment.Patient = patient;
                    appointment.Service = service;

                    await _appointmentsDbContext.Appointments.AddAsync(appointment);
                    _appointmentsDbContext.SaveChanges();

                    return true;
                }
                return false;
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
                var doctor = _appointmentsDbContext.Doctors
                    .FirstOrDefault(doctor => doctor.Id == appointment.DoctorId);

                var patient = _appointmentsDbContext.Patients
                    .FirstOrDefault(patient => patient.Id == appointment.PatientId);

                var service = _appointmentsDbContext.Services
                    .FirstOrDefault(service => service.Id == appointment.ServiceId);

                if (doctor is not null & patient is not null & service is not null)
                {
                    appointment.PatientId = entity.PatientId;
                    appointment.DoctorId = entity.DoctorId;
                    appointment.ServiceId = entity.ServiceId;
                    appointment.DateTime = entity.DateTime;
                    appointment.IsApproved = entity.IsApproved;
                    appointment.Doctor = doctor;
                    appointment.Patient = patient;
                    appointment.Service = service;

                    _appointmentsDbContext.SaveChanges();

                    return true;
                }
                return false;
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
