using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishStartServer.Database.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int DiffictlyLevel { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Article> Articles { get; set; }
        public List<ApplicationUserCourse> UserCourses { get; set; } = new List<ApplicationUserCourse>();
    }
}