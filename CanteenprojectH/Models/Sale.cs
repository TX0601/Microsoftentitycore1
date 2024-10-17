using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CanteenprojectH.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentType { get; set; } // "Cash", "UPI", "Debit/Credit Card"
        
           
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
