namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Boolean Subscribed { get; set; }
        public string? Branch { get; set; }
        public string? Semester { get; set; }
    }
}
