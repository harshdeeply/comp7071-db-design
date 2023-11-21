namespace hr_webapi.Models
{
    public class Employee: Person
    {
        public Guid EmployeeId { get; set; }
        public EmergencyContact? EmergencyContactInfo { get; set; }
        public  string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string EmploymentType { get; set; }
        public List<EmploymentEvent> EmploymentEvents { get; set; } = new List<EmploymentEvent>();
        public  PayInfo? PayInfo { get; set; }
        public double WorkShift { get; set; }
        public double AttendanceRate { get; set; }
        public  Employee? Manager { get; set; }
        public List<Shift> Shifts { get; set; } = new List<Shift>();
        public  ICollection<DayOff>? DayOffs { get; set; }
        public List<Paycheque> PayCheques { get; set; } = new List<Paycheque>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}