using Appointments.Domain.Entities;
using Appointments.Domain.Interfaces.Repositories;
using AutoMapper;
using Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Consumer.Events.Patients
{
    public class PatientDeletedConsumer : IConsumer<PatientDeleted>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientDeletedConsumer(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<PatientDeleted> context)
        {
            var patient = _mapper.Map<Patient>(context.Message);
            if (patient is not null)
            {
                _patientRepository.DeletePatient(patient);
            }
        }
    }
}
