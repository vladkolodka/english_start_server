using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 6)]
        public int DiffictlyLevel { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();
        public List<ApplicationUserCourse> UserCourses { get; set; } = new List<ApplicationUserCourse>();
    }
}