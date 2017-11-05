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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

//        [Required]
//        public Guid OwnerId { get; set; }
//        public ApplicationUser Owner { get; set; }

        public List<Article> Articles { get; set; }
    }
}