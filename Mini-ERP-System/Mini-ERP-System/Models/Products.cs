using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public double Price { get; set; }
        public int StocksAvailable { get; set; }
        [JsonIgnore]
        public ICollection<SalesOrder> SalesOrders { get; set; }
        [JsonIgnore]
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }


    }
}
