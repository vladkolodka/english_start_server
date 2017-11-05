using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class File
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContentType { get; set; }

        public Guid OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }
    }
}