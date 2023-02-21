using Events;
using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using MassTransit;

namespace Appointments.Application.Consumer.Events
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdated>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceUpdatedConsumer(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<ServiceUpdated> context)
        {
            var service = _mapper.Map<Service>(context.Message);
            if (service is not null)
            {
                _serviceRepository.UpdateService(service);
            }
        }
    }
}
