using System.Text.Json.Serialization;

namespace hr_webapi.Models;
public class Shift
{
    [JsonIgnore]
    public Employee? Employee { get; set; }
    public Guid ShiftId { get; set; }
    public DateTime ScheduledTimeIn { get; set; }
    public DateTime ScheduledTimeOut { get; set; }
    public DateTime ActualTimeIn { get; set; }
    public DateTime ActualTimeOut { get; set; }
    public DateTime VacationDaysLeft { get; set; }
    public DateTime BreakTimeIn { get; set; }
    public DateTime BreakTimeOut { get; set; }
    [JsonIgnore]
    public Paycheque? Paycheque { get; set; }
}