using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CanteenprojectH.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int StockIn { get; set; } // Amount of stock added

        public int StockOut { get; set; } // Amount of stock sold or removed

        public DateTime StockDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
    }
}
