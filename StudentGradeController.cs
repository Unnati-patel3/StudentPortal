using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using System.Linq;

namespace StudentPortal.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentGradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentGradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/StudentGrade/addStudentGrade
        [HttpPost]
        public IActionResult AddStudentGrade([FromBody] StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentGrades.Add(studentGrade);
            _context.SaveChanges();

            return Ok(studentGrade);
        }
    }
}
