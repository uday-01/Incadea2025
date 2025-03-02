using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        [EmailAddress]
        public required string CustomerEmail { get; set; }
        public required string CustomerAddress { get; set; }
        [JsonIgnore]
        public ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
