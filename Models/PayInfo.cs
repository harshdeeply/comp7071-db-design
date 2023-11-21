namespace hr_webapi.Models
{
    public class PayInfo
    {
        public Guid PayInfoId { get; set; }
        public double Salary { get; set; }
        public double HourlyWage { get; set; }
        public double OvertimeRate { get; set; }
        public int SickDaysLeft { get; set; }
        public double VacationDaysLeft { get; set; }
        public double MaxBreakTime { get; set; }
        public string DirectDepositAccountNumber { get; set; }
        public string DirectDepositBranchNumber { get; set; }
        public string DirectDepositTransitNumber { get; set; }
    }
}