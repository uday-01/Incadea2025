using System.ComponentModel.DataAnnotations;

namespace Assignment9.Model
{
    public class Students
    {
        [Key]
        public string Name { get; set; }
        public string pass { get; set; }
        public string branch { get; set; }
    }
}
