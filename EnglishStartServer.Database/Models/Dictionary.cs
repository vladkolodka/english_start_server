using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class Dictionary
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool IsPublic { get; set; } = false;

        public DateTime DateCreated { get; set; }

        public Guid? ImageId { get; set; }
        public File Image { get; set; }

        public Guid SourceLanguageId { get; set; }
        public Language SourceLanguage { get; set; }

        public List<Word> Words { get; set; } = new List<Word>();
        public List<ApplicationUserDictionary> UserDictionaries { get; set; } = new List<ApplicationUserDictionary>();
    }
}