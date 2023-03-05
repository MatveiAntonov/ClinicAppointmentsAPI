namespace Appointments.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = new();
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; } = new();
        public int? ServiceId { get; set; }
        public Service? Service { get; set; } = new();
        public DateTime? DateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
