using System;

namespace EnglishStartServer.Dto
{
    public class WordModel
    {
        public Guid Id { get; set; }

        public string Original { get; set; }

        public string Translation { get; set; }

        public Guid DictionaryId { get; set; }

        public string ImageUrl { get; set; }

        public int Stage { get; set; }
    }
}