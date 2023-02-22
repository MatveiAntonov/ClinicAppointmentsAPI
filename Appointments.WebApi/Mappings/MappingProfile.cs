using Appointments.Domain.Entities;
using Appointments.WebApi.Models.DTOs;
using AutoMapper;
using Events;

namespace Appointments.WebApi.Mappings;
public class MappingProfile : Profile {
    public MappingProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Result, ResultDto>().ReverseMap();

        CreateMap<Service, ServiceCreated>().ReverseMap();
        CreateMap<Service, ServiceUpdated>().ReverseMap();
        CreateMap<Service, ServiceDeleted>().ReverseMap();
        
        CreateMap<Doctor, DoctorCreated>().ReverseMap();
        CreateMap<Doctor, DoctorUpdated>().ReverseMap();
        CreateMap<Doctor, DoctorDeleted>().ReverseMap();

        CreateMap<Patient, PatientCreated>().ReverseMap();
        CreateMap<Patient, PatientUpdated>().ReverseMap();
        CreateMap<Patient, PatientDeleted>().ReverseMap();
    }
}
