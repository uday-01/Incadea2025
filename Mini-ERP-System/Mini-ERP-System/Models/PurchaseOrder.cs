using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        [JsonIgnore]
        public  Suppliers Suppliers { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public  Users Users { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public  Products Products { get; set; }
        public int QuantityPurchased { get; set; }
        public int TotalPurchaseAmount { get; set; }


    }
}
