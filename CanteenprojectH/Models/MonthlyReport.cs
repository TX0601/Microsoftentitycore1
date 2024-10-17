using System.ComponentModel.DataAnnotations;

namespace CanteenprojectH.Models
{
    public class MonthlyReport
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        public DateTime ReportMonth { get; set; } // Date representing the month, e.g., 2024-10

        [Required]
        public int TotalSales { get; set; } // Total number of sales made in the month

        [Required]
        public decimal TotalRevenue { get; set; } // Total revenue generated in the month

        [Required]
        public int ProductsSold { get; set; } // Total number of products sold

        [Required]
        public int StockAdded { get; set; } // Total stock added during the month

        [Required]
        public int StockRemoved { get; set; } // Total stock removed or sold during the month
    }
}
