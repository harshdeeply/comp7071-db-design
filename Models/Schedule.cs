namespace hr_webapi.Models;
public class Schedule
{
    public Guid ScheduleId { get; set; }
    public DateTime ScheduledTimeIn { get; set; }
    public DateTime ScheduledTimeOut { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public List<Shift> Shifts { get; set; } = new List<Shift>();
}