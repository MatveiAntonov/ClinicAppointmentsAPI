using Appointments.Domain.Entities;

namespace Appointments.Domain.Interfaces.Repositories
{
    public interface IServiceRepository
    {
        Task<bool> CreateService(Service service);
        bool UpdateService(Service service);
        bool DeleteService(Service service);
    }
}
