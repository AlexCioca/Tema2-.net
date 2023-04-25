using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class GradesController:ControllerBase
    {
        private readonly GradeService gradesService;

        public GradesController(GradeService gradesService)
        {
            this.gradesService = gradesService; 
        }

        [HttpPost("AddGrade")]
        public IActionResult AddGrade([FromBody] GradeAddDto newGrade)
        {
            var result = gradesService.AddGrade(newGrade);
            if (result == null)
            {
                return BadRequest("Grade cannot be added");
            }

            return Ok(result);

        }

        [HttpGet("GetGradesInOrder")]
        public IActionResult GetGradesInOrder(int studentId)
        {
            var result = gradesService.GetStudentGradesOrdered(studentId);
            if (result == null)
            {
                return BadRequest("Grade cannot be get");
            }

            return Ok(result);
        }
    }
}
