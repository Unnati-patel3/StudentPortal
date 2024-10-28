using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Models;

namespace StudentPortal.Web.Data
{
    public class ApplicationDbContext: DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        
        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
