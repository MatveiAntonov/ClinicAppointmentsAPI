
namespace Appointments.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientId { get; set; } = String.Empty;
        public string DoctorId { get; set; } = String.Empty;
        public string? ServiceId { get; set; } = String.Empty;
        public DateTime? DateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
