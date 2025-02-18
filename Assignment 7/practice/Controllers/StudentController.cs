using Microsoft.AspNetCore.Mvc;

namespace practice.Controllers
{

    [Route("api/")]
    
    public class StudentController : Controller
    {

        private static readonly List<student> students = new List<student>()
        {
new student() {Id =1, Name ="Ram",Age=21,Course="DBMS" },
new student(){ Id= 2,Name="shyam",Age=32,Course="OS"},
new student(){ Id= 3,Name="Gwalior",Age=23,Course="API"}

        };
        
        [HttpGet]
        [Route("students/")]
        public ActionResult<IEnumerable<student>> GetStudents()
        {
            return Ok(students);
        }

        //read
        [HttpGet]
        [Route("student/{id}")]
        public ActionResult<student> GetStudent([FromRoute]int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //create
        [HttpPost]
        [Route("student/")]
        public ActionResult<student> AddStudent([FromBody] student student)
        {
            students.Add(student);
            return Ok(" Created");
        }

        //update
        [HttpPut]
        [Route("student/{id}")]
        public ActionResult UpdateStudent([FromRoute] int id, [FromBody] student updatedStudent)
        {
            student stud = students.Find(s => s.Id == id);

            if (stud == null)
            {
                return NotFound(); // Return 404 if student is not found
            }

            stud.Name = updatedStudent.Name;
            stud.Age = updatedStudent.Age;
            stud.Course = updatedStudent.Course;

            return Ok("student added"); // Return 204 No Content
        }


        //delete
        [HttpDelete]
        [Route("student/{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            students.Remove(student);
            return Ok("student deleted");
        }


       
        
    }
}
