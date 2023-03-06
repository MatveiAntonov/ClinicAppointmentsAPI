using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using MassTransit;
using Events;

namespace Appointments.Application.Consumer.Events.Doctors
{
    public class DoctorDeletedConsumer : IConsumer<DoctorDeleted>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorDeletedConsumer(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<DoctorDeleted> context)
        {
            var doctor = _mapper.Map<Doctor>(context.Message);
            if (doctor is not null)
            {
                _doctorRepository.DeleteDoctor(doctor);
            }
        }
    }
}
