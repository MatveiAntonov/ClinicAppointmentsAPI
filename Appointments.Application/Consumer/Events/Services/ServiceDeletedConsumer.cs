using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using MassTransit;
using Events;

namespace Appointments.Application.Consumer.Events.Services
{
    public class ServiceDeletedConsumer : IConsumer<ServiceDeleted>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceDeletedConsumer(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<ServiceDeleted> context)
        {
            var service = _mapper.Map<Service>(context.Message);
            if (service is not null)
            {
                _serviceRepository.DeleteService(service);
            }
        }
    }
}
