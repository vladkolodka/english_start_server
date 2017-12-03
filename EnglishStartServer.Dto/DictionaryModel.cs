using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishStartServer.Dto
{
    public class DictionaryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        public string SourceLanguage { get; set; }

        public bool IsPublic { get; set; }

        public List<WordModel> Words { get; set; }
        public bool LearningStatus { get; set; }
    }
}