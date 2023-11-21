namespace hr_webapi.Models
{
    public class PayDetail
    {
        public Guid PayDetailId { get; set; }
        public  string PayType { get; set; }
        public double Rate { get; set; }
        public double Hours { get; set; }
    }
}