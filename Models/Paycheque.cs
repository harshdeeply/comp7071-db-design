using System.Text.Json.Serialization;

namespace hr_webapi.Models
{
    public class Paycheque
    {
        public Guid PaychequeId { get; set; }
        [JsonIgnore]
        public  Employee Employee { get; set; }
        public  Shift[] Shifts { get; set; }
        public DateTime PayDate { get; set; }
        public double PayTotal { get; set; }
        public  PayDetail[] PayDetails { get; set; }
        public DateTime PayStartDate { get; set; }
        public DateTime PayEndDate { get; set; }
        public  DeductionDetail[] Deductions { get; set; }
    }
}