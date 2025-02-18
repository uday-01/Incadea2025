using System.ComponentModel.DataAnnotations;

namespace Assignment8.Models
{
    public class EmployeeTable
    {
        
        public int empid { get; set; }
        [Required]
        public string empname { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
        public int deptid { get; set; }

       public DepartmentTable departmentTable { get; set; }
    }
}
