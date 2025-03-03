using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Erpsystemfinal.Migrations;

namespace Erpsystemfinal.Models
{
    public class PurchaseOrders
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [JsonIgnore]
        public virtual Suppliers? Supplier { get; set; }  

        [Required]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Products? Product { get; set; }

        [Required]
        public int purchasequantity { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }
}
