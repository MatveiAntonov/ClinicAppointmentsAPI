using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<bool> CreatePatient(Patient patient);
        bool UpdatePatient(Patient patient);
        bool DeletePatient(Patient patient);
    }
}
