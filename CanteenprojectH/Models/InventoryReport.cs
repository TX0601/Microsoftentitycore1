namespace CanteenprojectH.Models
{
    public class InventoryReport
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public DateTime StockDate { get; set; }
    }
}
