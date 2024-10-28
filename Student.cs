﻿namespace StudentPortal.Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Branch { get; set; }
        public string? Semester { get; set; }
        public bool Subscribed { get; set; }
    }
}