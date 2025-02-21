using System.ComponentModel.DataAnnotations;

namespace EmployeeAuthPractice.Modules
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
