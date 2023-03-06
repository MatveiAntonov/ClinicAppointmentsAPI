using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Persistence.Contexts;

namespace Appointments.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppointmentsDbContext _appointmentsDbContext;

        public DoctorRepository(AppointmentsDbContext appointmentsDbContext)
        {
            _appointmentsDbContext = appointmentsDbContext;
        }

        public async Task<bool> CreateDoctor(Doctor doctor)
        {
            try
            {
                await _appointmentsDbContext.Doctors.AddAsync(doctor);
                _appointmentsDbContext.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool UpdateDoctor(Doctor entity)
        {
            if (entity is null)
            {
                return false;
            }

            var doctor = _appointmentsDbContext.Doctors.FirstOrDefault(x => x.Id == entity.Id);

            if (doctor is not null)
            {
                try
                {
                    doctor.FirstName = entity.FirstName;
                    doctor.LastName = entity.LastName;
                    doctor.MiddleName = entity.MiddleName;
                    doctor.SpecializationName = entity.SpecializationName;
                    doctor.PhotoUrl = entity.PhotoUrl;
                    doctor.OfficeName = entity.OfficeName;
                    doctor.OfficeCity = entity.OfficeCity;
                    doctor.OfficeRegion = entity.OfficeRegion;
                    doctor.OfficeStreet = entity.OfficeStreet;
                    doctor.OfficePostalCode = entity.OfficePostalCode;
                    doctor.OfficeHouseNumber = entity.OfficeHouseNumber;

                    _appointmentsDbContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool DeleteDoctor(Doctor doctor)
        {
            try
            {
                _appointmentsDbContext.Doctors.Remove(doctor);
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
