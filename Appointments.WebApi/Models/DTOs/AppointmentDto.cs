using Appointments.Domain.Entities;

namespace Appointments.WebApi.Models.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = new();
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = new();
        public int? ServiceId { get; set; }
        public Service? Service { get; set; } = new();
        public DateTime? DateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
