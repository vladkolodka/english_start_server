using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishStartServer.Database.Models
{
    public class Dictionary
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublic { get; set; } = false;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

//        [Required]
//        public Guid OwnerId { get; set; }
//        public ApplicationUser Owner { get; set; }

        public Guid ImageId { get; set; }
        public File Image { get; set; }

        public Guid SourceLanguageId { get; set; }
        public Language SourceLanguage { get; set; }
//
//        [Required]
//        public Guid TargetLanguageId { get; set; }
//        public Language TargetLanguage { get; set; }

        public List<Word> Words { get; set; }
    }
}