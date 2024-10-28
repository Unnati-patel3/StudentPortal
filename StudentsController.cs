using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;

namespace StudentPortal.Web.Controllers
{
    //[ApiController]
    //[Route("api/[controller]/[]")]
    public class StudentsController : Controller
	{
		private readonly ApplicationDbContext dbContext;
		public StudentsController(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;

		}

		//public ApplicationDbContext? DbContext { get; }

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddStudentViewModel viewModel)
		{
			var student = new Student
			{
				Name = viewModel.Name,
				Email = viewModel.Email,
				Phone = viewModel.Phone,
				Branch = viewModel.Branch,
				Semester = viewModel.Semester,
				Subscribed = viewModel.Subscribed
			};

			await dbContext.Students.AddAsync(student);
			await dbContext.SaveChangesAsync();
			//dbContext.SaveChanges();

			return View();
		}

		[HttpGet]
		public IActionResult AddSub()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddSub(Subjects viewModel)
		{
			if (!ModelState.IsValid)
			{
				// If the model state is invalid, return the same view to show validation errors
				return View(viewModel);
			}

			var subject = new Subjects
			{
				Id = viewModel.Id,
				Subject = viewModel.Subject,
				Branch = viewModel.Branch,
				Semester = viewModel.Semester
			};

			await dbContext.Subjects.AddAsync(subject);
			await dbContext.SaveChangesAsync();

			//return View();
			return RedirectToAction("AddSub");
		}

        [HttpGet]
		public async Task<IActionResult> List()
		{
			var students = await dbContext.Students.ToListAsync();

			return View(students);
		}

		[HttpGet("Students/List/{name}")]
		public async Task<IActionResult> List(string? name = null)
		{
			var students = dbContext.Students.AsQueryable();

			if (!string.IsNullOrEmpty(name))
			{
				students = students.Where(s => s.Name.Contains(name));
				ViewData["SearchName"] = name;
			}
			else
			{
				ViewData["SearchName"] = null;
			}
			return View("List", await students.ToListAsync());
		}

		[HttpGet]
		public async Task<IActionResult> StudentList()
		{
			var students = await dbContext.Students.ToListAsync();

			return View(students);
		}

		[HttpGet("Students/StudentList/{name}")]
		public async Task<IActionResult> StudentList(string? name = null)
		{
			var students = dbContext.Students.AsQueryable();

			if (!string.IsNullOrEmpty(name))
			{
				students = students.Where(s => s.Name.Contains(name));
				ViewData["SearchName"] = name;
			}
			else
			{
				ViewData["SearchName"] = null;
			}
			return View("List", await students.ToListAsync());
		}

		[HttpGet("Students/Count/{name?}")]
		public async Task<IActionResult> Count(string? name = null)
		{
			int studentCount = 0;

			if (!string.IsNullOrEmpty(name))
			{
				studentCount = await dbContext.Students.CountAsync(s => s.Name.Contains(name));
			}

			ViewData["StudentCount"] = studentCount;
			ViewData["SearchName"] = name;

			return View();
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int Id)
		{
			var student = await dbContext.Students.FindAsync(Id);

			return View(student);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Student viewModel)
		{
			var student = await dbContext.Students.FindAsync(viewModel.Id);

			if (student is not null)
			{
				student.Name = viewModel.Name;
				student.Email = viewModel.Email;
				student.Phone = viewModel.Phone;
				student.Branch = viewModel.Branch;
				student.Semester = viewModel.Semester;
				student.Subscribed = viewModel.Subscribed;

				await dbContext.SaveChangesAsync();
			}

			return RedirectToAction("List", "Students");
		}

		public async Task<IActionResult> Delete(Student viewModel)
		{
			var student = await dbContext.Students
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == viewModel.Id);

			if (student is not null)
			{
				dbContext.Students.Remove(viewModel);
				await dbContext.SaveChangesAsync();
			}

			return RedirectToAction("List", "Students");
		}

		// GET: Students
		public async Task<IActionResult> Index()
		{
			return View(await dbContext.Students.ToListAsync());
		}

		// GET: Students/Details/5
		public async Task<IActionResult> StudentList(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = await dbContext.Students
				.FirstOrDefaultAsync(m => m.Id == id);
			if (student == null)
			{
				return NotFound();
			}

			return View(student);
		}

        [HttpGet]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Json(new { name = student.Name, branch = student.Branch, semester = student.Semester });
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = dbContext.Students
                                  .Where(s => s.Id == id)
                                  .Select(s => new { s.Name, s.Branch, s.Semester })
                                  .FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

    }
}
