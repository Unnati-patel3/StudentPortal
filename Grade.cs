using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Web.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Branch { get; set; }
        public string? Semester { get; set; }
        public string? Subject1 { get; set; }
        public string? Grade1 { get; set; }
        public string? Subject2 { get; set; }
        public string? Grade2 { get; set; }
        public string? Subject3 { get; set; }
        public string? Grade3 { get; set; }
        public string? Subject4 { get; set; }
        public string? Grade4 { get; set; }
        public string? Subject5 { get; set; }
        public string? Grade5 { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
