namespace hr_webapi.Models;
public class Shift
{
    public Guid ShiftId { get; set; }
    public DateTime ActualTimeIn { get; set; }
    public DateTime ActualTimeOut { get; set; }
    public DateTime BreakTimeIn { get; set; }
    public DateTime BreakTimeOut { get; set; }
}