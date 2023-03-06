using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using Events;
using MassTransit;

namespace Appointments.Application.Consumer.Events.Patients
{
    public class PatientUpdatedConsumer : IConsumer<PatientUpdated>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientUpdatedConsumer(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<PatientUpdated> context)
        {
            var patient = _mapper.Map<Patient>(context.Message);
            if (patient is not null)
            {
                _patientRepository.UpdatePatient(patient);
            }
        }
    }
}
