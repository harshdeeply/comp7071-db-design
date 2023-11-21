namespace hr_webapi.Models
{
    public class EmploymentEvent
    {
        public Guid EmploymentEventId { get; set; }
        public int Day { get; set; }
        public string? Event { get; set; }
    }
}