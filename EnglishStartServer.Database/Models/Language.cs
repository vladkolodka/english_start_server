using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class Language
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}