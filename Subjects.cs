using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Web.Models
{
    public class Subjects
    {
        public string? Branch { get; set; }
        public string? Semester { get; set; }
        public int Id { get; set; }
        public string? Subject { get; set; }

    }
}
