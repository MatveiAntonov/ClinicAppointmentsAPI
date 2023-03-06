using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using Appointments.Persistence.Contexts;

namespace Appointments.Persistence.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppointmentsDbContext _appointmentsDbContext;

        public ServiceRepository(AppointmentsDbContext appointmentsDbContext)
        {
            _appointmentsDbContext = appointmentsDbContext;
        }

        public async Task<bool> CreateService(Service service)
        {
            try
            {
                await _appointmentsDbContext.Services.AddAsync(service);
                _appointmentsDbContext.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool UpdateService(Service entity)
        {
            if (entity is null)
            {
                return false;
            }

            var service = _appointmentsDbContext.Services.FirstOrDefault(x => x.Id == entity.Id);

            if (service is not null)
            {
                try
                {
                    service.ServicePrice = entity.ServicePrice;
                    service.ServiceName = entity.ServiceName;
                    service.ServiceCategoryName = entity.ServiceCategoryName;
                    service.SpecializationName = entity.SpecializationName;
                    service.TimeSlotSize = entity.TimeSlotSize;

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

        public bool DeleteService(Service service)
        {
            try
            {
                _appointmentsDbContext.Services.Remove(service);
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
