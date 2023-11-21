using System.Text.Json.Serialization;

namespace hr_webapi.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? EmergencyContactRelationship { get; set; }
        public  string? JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string? EmploymentType { get; set; }
        [JsonIgnore]
        public  EmploymentEvent[]? EmploymentEvents { get; set; }
        public  Guid PayInfoId { get; set; }
        [JsonIgnore]
        public  PayInfo? PayInfo { get; set; }
        public double WorkShift { get; set; }
        public  object? PayHistory { get; set; }
        public double AttendanceRate { get; set; }
        [JsonIgnore]
        public  Employee? Manager { get; set; }
        [JsonIgnore]
        public  Shift[]? Shifts { get; set; }
        [JsonIgnore]
        public DayOff[]? DayOffs { get; set; }
        [JsonIgnore]
        public  Paycheque[]? PayCheques { get; set; }
    }
}