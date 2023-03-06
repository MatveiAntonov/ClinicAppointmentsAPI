using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using MassTransit;
using Events;

namespace Appointments.Application.Consumer.Events.Doctors
{
    public class DoctorCreatedConsumer : IConsumer<DoctorCreated>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorCreatedConsumer(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<DoctorCreated> context)
        {
            var doctor = _mapper.Map<Doctor>(context.Message);
            if (doctor is not null)
            {
                await _doctorRepository.CreateDoctor(doctor);
            }
        }
    }
}
