using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class ApplicationUserCourse
    {
        public Guid ApplicationUserId { get; set; }
        public Guid CourseId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Course Course { get; set; }

        public bool IsStudied { get; set; } = false;

        [Required]
        public bool IsOwner { get; set; } = false;
    }
}