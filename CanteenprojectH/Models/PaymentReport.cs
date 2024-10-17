namespace CanteenprojectH.Models
{
    public class PaymentReport
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
