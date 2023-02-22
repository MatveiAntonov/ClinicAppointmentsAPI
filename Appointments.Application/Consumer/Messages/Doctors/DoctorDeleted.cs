namespace Events
{
    public class DoctorDeleted
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string? MiddleName { get; set; } = String.Empty;
        public string SpecializationName { get; set; } = String.Empty;
        public string PhotoUrl { get; set; } = String.Empty;
        public string? OfficeName { get; set; } = String.Empty;
        public string OfficeCity { get; set; } = String.Empty;
        public string OfficeRegion { get; set; } = String.Empty;
        public string OfficeStreet { get; set; } = String.Empty;
        public string? OfficePostalCode { get; set; } = String.Empty;
        public int OfficeHouseNumber { get; set; }
    }
}
