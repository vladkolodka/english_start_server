using System;
using System.Collections.Generic;

namespace EnglishStartServer.Dto
{
    public class AddWordsModel
    {
        public Guid DictionaryId { get; set; }
        public List<WordModel> Words { get; set; }
    }
}