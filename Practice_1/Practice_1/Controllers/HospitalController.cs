
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice_1.Data;
using Practice_1.Models;

namespace Practice_1.Controllers
{
    [Route("api/")]
    public class HospitalController : Controller
    {
        
        public readonly HospitalDbContext context;
        public HospitalController(HospitalDbContext _context) {
            context = _context;
        }
        [HttpPost]
        [Route("Patient/")]
        [Authorize(Roles ="Doctor")]
        public IActionResult AddPatient([FromBody] Hospital patient)
        {
            patient.Role = "Patient";
            context.Add(patient);
            context.SaveChanges();
            return Ok("Patient Added Successfully");
        }
        [HttpGet]
        [Route("Patients/")]
        public IActionResult GetAllPatients()
        {
            var list = context.hospitals.Where(i => i.Role == "Patient");
            return Ok(list);
        }
        [HttpGet]
        [Route("Patient/{id}")]
        public IActionResult GetPatientById([FromRoute] string id)
        {
            var patient = context.hospitals.Where(i => i.Id == id && i.Role=="Patient").FirstOrDefault();
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound("Patient not found");
        }

        [HttpDelete]
        [Route("Patient/{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult DeletePatient([FromRoute] string id)
        {
            var PatientToBeDeleted = context.hospitals.Where(i => i.Id == id && i.Role == "Patient").FirstOrDefault();
            if (PatientToBeDeleted != null)
            {
                context.hospitals.Remove(PatientToBeDeleted);
                context.SaveChanges();
                return Ok("Patient Deleted Successfully");
            }
            return NotFound("Patient not found");
        }
        [HttpPut]
        [Route("Patient/{id}")]
        [Authorize(Roles = "Doctor")]
        public IActionResult UpdatePatient([FromBody] Hospital Patient,[FromRoute]string id)
        {
            var ExistingPatient = context.hospitals.Where(i => i.Id == id && i.Role == "Patient").FirstOrDefault();
            if (ExistingPatient != null)
            {
                ExistingPatient.Username = Patient.Username;
                ExistingPatient.Password = Patient.Password;
                ExistingPatient.Role = "Patient";
                context.Update(ExistingPatient);
                context.SaveChanges();
                return Ok("Patient Updated Succesfully");
            }
            return NotFound("Patient not found");
        }


    }
}
