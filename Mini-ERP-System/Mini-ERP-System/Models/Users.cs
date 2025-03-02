using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mini_ERP_System.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        [JsonIgnore]
        public ICollection<SalesOrder> SalesOrders { get; set; }
        [JsonIgnore]
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
