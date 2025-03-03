using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erpsystemfinal.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
        [JsonIgnore]
        public List<PurchaseOrders> PurchaseOrders { get; set; }
    }
}
