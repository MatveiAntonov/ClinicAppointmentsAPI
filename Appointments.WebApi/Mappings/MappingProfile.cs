using Events;
using Appointments.Domain.Entities;
using Appointments.WebApi.Models.DTOs;
using AutoMapper;

namespace Appointments.WebApi.Mappings; 
public class MappingProfile : Profile {
    public MappingProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Result, ResultDto>().ReverseMap();

        CreateMap<Service, ServiceCreated>().ReverseMap();
        CreateMap<Service, ServiceUpdated>().ReverseMap();
        CreateMap<Service, ServiceDeleted>().ReverseMap();
    }
}
