using System.Text.Json.Serialization;

namespace hr_webapi.Models
{
    public class DayOff
    {
        public Guid DayOffId { get; set; }
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public  Employee? Employee { get; set; }
        public  string? Type { get; set; }
        public  string? Reason { get; set; }
        public  string? Shift { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string? Status { get; set; }
    }
}