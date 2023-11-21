namespace hr_webapi.Models
{
    public class DeductionDetail
    {
        public Guid DeductionDetailId { get; set; }
        public string DeductionType { get; set; }
        public double TotalAmount { get; set; }
    }
}