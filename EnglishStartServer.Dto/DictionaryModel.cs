using System;
using System.Collections.Generic;

namespace EnglishStartServer.Dto
{
    public class DictionaryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        public string SourceLanguage { get; set; }

        public List<WordModel> Words { get; set; }
    }
}