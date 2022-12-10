using Blazor.Shared.Models;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentOpsController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        public StudentOpsController(IStudentServices _studentServices) {

            studentServices = _studentServices;
        }


        [HttpGet]
        [Route("get-students-list")]
        public async Task<IActionResult> GetStudentsList()
        {
            List<StudentEntity> students = new List<StudentEntity>();

            students = studentServices.GetAllStudent().ToList();

            return Ok(students);
        }


        [HttpPost]
        [Route("post-student")]
        public async Task<IActionResult> AddNewStudent(StudentEntity studentEntity)
        {
            try
            {
                 studentServices.AddStudent(studentEntity);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete]
        [Route("delete-student/{StudentID}")]
        public async Task<IActionResult> GetStudentsList(int StudentID)
        {
           
            studentServices.DeleteStudent(StudentID);

            return Ok();
        }



        [HttpPost]
        [Route("update-student")]
        public async Task<IActionResult> UpdateStudent(StudentEntity studentEntity)
        {
            try
            {
                studentServices.UpdateStudent(studentEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
