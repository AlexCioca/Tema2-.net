using Core.Dtos;
using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private StudentService studentService { get; set; }
        private CurrentUserService currentUserService { get; set; } 
        private UserService userService { get; set; }


        public StudentsController(StudentService studentService, CurrentUserService currentUserService, UserService userService)
        {
            this.studentService = studentService;
            this.currentUserService = currentUserService;
            this.userService = userService;
        }

        [HttpPost("/add")]
        public IActionResult Add(StudentAddDto payload)
        {
            var result = studentService.AddStudent(payload);

            if (result == null)
            {
                return BadRequest("Student cannot be added");
            }

            return Ok(result);
        }


        [HttpGet("/get-all")]
        public ActionResult<List<Student>> GetAll()
        {
            var results = studentService.GetAll();

            return Ok(results);
        }

        [HttpGet("/get/{studentId}")]
        public ActionResult<Student> GetById(int studentId)
        {
            var result = studentService.GetById(studentId);

            if(result == null)
            {
                return BadRequest("Student not fount");
            }

            return Ok(result);
        }

        [HttpPatch("edit-name")]
        public ActionResult<bool> GetById([FromBody] StudentUpdateDto studentUpdateModel)
        {
            var result = studentService.EditName(studentUpdateModel);

            if (!result)
            {
                return BadRequest("Student could not be updated.");
            }

            return result;
        }

        [HttpPost("grades-by-course"),Authorize("STUDENT")]
        public ActionResult<GradesByStudent> Get_CourseGrades_ByStudentId([FromBody] StudentGradesRequest request)
        {
            var username = currentUserService.GetName(Request.Headers["Authorization"]);
            var student = studentService.GetById(request.StudentId);
            var user = userService.GetUser(username);

            if(student.UserId!=user.UserId)
            {
                return BadRequest("Not Allowed");
            }

            var result = studentService.GetGradesById(request.StudentId, request.CourseType);
            return Ok(result);
        }
        [HttpPost("grades-by-course-PROFFESOR"), Authorize("PROFFESOR")]
        public ActionResult<GradesByStudent> Get_CourseGrades_ByStudentId_Proffesor([FromBody] StudentGradesRequest request)
        {
           
            var result = studentService.GetGradesById(request.StudentId, request.CourseType);
            return Ok(result);
        }

        [HttpGet("{classId}/class-students")]
        public IActionResult GetClassStudents([FromRoute] int classId)
        {
            var results = studentService.GetClassStudents(classId);

            return Ok(results);
        }

        [HttpGet("grouped-students")]
        public IActionResult GetGroupedStudents()
        {
            var results = studentService.GetGroupedStudents();

            return Ok(results);
        }
    }
}
