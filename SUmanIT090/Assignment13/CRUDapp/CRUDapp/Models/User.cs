using System.ComponentModel.DataAnnotations;

namespace CRUDapp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

    public class UserLogin
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
