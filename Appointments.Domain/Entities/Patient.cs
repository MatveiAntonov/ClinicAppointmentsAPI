namespace Appointments.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string? MiddleName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhotoUrl { get; set; } = String.Empty;
    }
}
