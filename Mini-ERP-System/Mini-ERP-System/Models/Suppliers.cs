using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class Suppliers
    {
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; }
        [EmailAddress]
        public required string SupplierEmail { get; set; }
        public required string SupplierAddress { get; set; }
        [JsonIgnore]
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
