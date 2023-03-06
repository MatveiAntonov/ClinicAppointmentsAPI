using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppointmentsDbContext _appointmentsDbContext;

        public PatientRepository(AppointmentsDbContext appointmentsDbContext)
        {
            _appointmentsDbContext = appointmentsDbContext;
        }

        public async Task<bool> CreatePatient(Patient patient)
        {
            try
            {
                await _appointmentsDbContext.Patients.AddAsync(patient);
                _appointmentsDbContext.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePatient(Patient entity)
        {
            if (entity is null)
            {
                return false;
            }

            var patient = _appointmentsDbContext.Patients.FirstOrDefault(x => x.Id == entity.Id);

            if (patient is not null)
            {
                try
                {
                    patient.FirstName = entity.FirstName;
                    patient.LastName = entity.LastName;
                    patient.MiddleName = entity.MiddleName;
                    patient.DateOfBirth = entity.DateOfBirth;
                    patient.PhotoUrl = entity.PhotoUrl;

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

        public bool DeletePatient(Patient patient)
        {
            try
            {
                _appointmentsDbContext.Patients.Remove(patient);
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
