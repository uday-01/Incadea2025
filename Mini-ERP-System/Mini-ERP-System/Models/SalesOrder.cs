using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public  Customers Customers { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public  Users Users { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public  Products Products { get; set; }
        public int QuantitySold { get; set; }
        public int TotalSalesAmount { get; set; }


    }
}
