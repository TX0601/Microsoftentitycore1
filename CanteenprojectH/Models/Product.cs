using System.ComponentModel.DataAnnotations;

namespace CanteenprojectH.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockLevel { get; set; }
    

        [Required]
        public string Category { get; set; } // Example: "Kitchen Use", "Men's Use", "Cosmetic", etc.
    }
}
