namespace hr_webapi.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public  string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public  string EmploymentType { get; set; }
        public  EmploymentEvent[] EmploymentEvents { get; set; }
        public  Guid PayInfoId { get; set; }
        public  PayInfo PayInfo { get; set; }
        public double WorkShift { get; set; }
        public  object PayHistory { get; set; }
        public double AttendanceRate { get; set; }
        public  Employee Manager { get; set; }
        public  Shift[] Shifts { get; set; }
        public  ICollection<DayOff> DayOffs { get; set; }
        public  Paycheque[] PayCheques { get; set; }
    }
}