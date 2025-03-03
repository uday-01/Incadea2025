using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erpsystemfinal.Models
{
    public class Customers
    {
        [Key] 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        [JsonIgnore]
        
        public List<SalesOrders> SalesOrders { get; set; }
    }
   
}
