using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Task<bool> CreateDoctor(Doctor doctor);
        bool UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(Doctor doctor);
    }
}
