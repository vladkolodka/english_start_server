using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class Word
    {
        public Guid Id { get; set; }

        [Required]
        public string Original { get; set; }

        [Required]
        public string Translation { get; set; }

        [Required]
        public Guid DictionaryId { get; set; }
        public Dictionary Dictionary { get; set; }

        public Guid? ImageId { get; set; }
        public File Image { get; set; }

        public List<ApplicationUserWord> UserWords { get; set; }

    }
}