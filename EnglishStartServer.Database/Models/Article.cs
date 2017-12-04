using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishStartServer.Database.Models
{
    public class Article
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime DateCreated { get; set; }

        public List<InformationBlock> InformationBlocks { get; set; } = new List<InformationBlock>();
    }
}