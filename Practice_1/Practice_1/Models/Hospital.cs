using System.ComponentModel.DataAnnotations;

namespace Practice_1.Models
{
    public class Hospital
    {
        [Key]
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
