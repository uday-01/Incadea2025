using System.ComponentModel.DataAnnotations;

namespace Assignment8.Models
{
    public class DepartmentTable
    {
        public int deptid {  get; set; }
        [Required]
        public string departmentName { get; set; }
       
    }
}
