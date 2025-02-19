using System.ComponentModel.DataAnnotations;

namespace Assignment10.Models
{
    public class Users
    {
        [Key]
        public string? Username {  get; set; }
        public string? Password { get; set; }
        public string? Role {  get; set; }

    }
}
