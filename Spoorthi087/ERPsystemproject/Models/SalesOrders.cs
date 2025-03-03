using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erpsystemfinal.Models
{
    public class SalesOrders
    {
        [Key]
        public int SalesOrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        
        public virtual Customers? Customer { get; set; }  

        [Required]
        public int ProductId { get; set; }

        
        public virtual Products? Product { get; set; }  

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}

