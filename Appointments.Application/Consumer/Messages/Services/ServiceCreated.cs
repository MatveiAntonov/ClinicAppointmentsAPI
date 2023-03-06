namespace Events
{
    public class ServiceCreated
    {
        public int Id { get; set; }
        public string ServiceCategoryName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public double? ServicePrice { get; set; }
        public string SpecializationName { get; set; } = string.Empty;
        public DateTime? TimeSlotSize { get; set; }
    }
}
