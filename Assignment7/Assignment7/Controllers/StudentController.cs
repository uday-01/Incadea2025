using Assignment7.Models;
using Microsoft.AspNetCore.Mvc;


namespace Assignment7.Controllers
{
    [Route("api/")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        [HttpPost]
        [Route("student/")]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            students.Add(student);
            return Ok("Student Added");
        }
        [HttpGet]
        [Route("student/{id}")]
        public ActionResult<Student> GetStudent([FromRoute]int id)
        {
            Student obj = students.Find(s=>s.Id==id);
            return Ok(obj);
        }
        [HttpGet]
        [Route("students/")]
        public ActionResult<Student> GetAllStudents()
        {
            return Ok(students);
        }
        [HttpPut]
        [Route("student/{id}")]
        public ActionResult<Student> UpdateStudent([FromRoute] int id, [FromBody] Student student)
        {
            Student stud = students.Find(s => s.Id == id);
            if (stud != null)
            {
                stud.Id = student.Id;
                stud.Name = student.Name;
                stud.Age = student.Age;
                return Ok("Student Updated");
            }
            
            return NotFound();
            
        }
        [HttpDelete]
        [Route("student/{id}")]
        public ActionResult<Student> DeleteStudent([FromRoute] int id)
        {
            Student stud = students.Find(s => s.Id == id);
            students.Remove(stud);
            return Ok("Student Deleted");
        }

    }
}
