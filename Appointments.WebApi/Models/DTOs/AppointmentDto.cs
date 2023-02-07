namespace Appointments.WebApi.Models.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string PatientId { get; set; } = String.Empty;
        public string DoctorId { get; set; } = String.Empty;
        public string? ServiceId { get; set; } = String.Empty;
        public DateTime? DateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
