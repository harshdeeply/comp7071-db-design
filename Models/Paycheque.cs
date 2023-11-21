namespace hr_webapi.Models
{
    public class Paycheque
    {
        public Guid PaychequeId { get; set; }
        public List<Shift> Shifts { get; set; } = new List<Shift>();
        public DateTime PayDate { get; set; }
        public double PayTotal { get; set; }
        public List<PayDetail> PayDetails { get; set; } = new List<PayDetail>();
        public DateTime PayStartDate { get; set; }
        public DateTime PayEndDate { get; set; }
        public List<DeductionDetail> Deductions { get; set; } = new List<DeductionDetail>();
    }
}