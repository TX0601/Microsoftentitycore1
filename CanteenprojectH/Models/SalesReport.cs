namespace CanteenprojectH.Models
{
    public class SalesReport
    {
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }
        public DateTime SaleDate { get; set; }

        public string ProductName { get; set; }
        public string UserName { get; set; }
    }
}
