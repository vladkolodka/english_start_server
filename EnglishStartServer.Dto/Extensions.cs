using System.Collections.Generic;
using System.Linq;
using EnglishStartServer.Database.Models;

namespace EnglishStartServer.Dto
{
    public static class Extensions
    {
        // requires external data
        public static DictionaryModel ToDto(this Dictionary d)
        {
            return new DictionaryModel
            {
                Id = d.Id,
                Name = d.Name,
                DateCreated = d.DateCreated,
                ImageUrl = d.ImageId.ToString(),
                SourceLanguage = d.SourceLanguage?.Name,
                Words = d.Words.ToDto()
            };
        }

        public static WordModel ToDto(this Word w)
        {
            return new WordModel
            {
                Id = w.Id,
                Original = w.Original,
                Translation = w.Translation,
                ImageUrl = w.ImageId.ToString(),
                DictionaryId = w.DictionaryId
            };
        }

        public static List<DictionaryModel> ToDto(this IEnumerable<Dictionary> dictionaries)
        {
            return dictionaries.Select(d => d.ToDto()).ToList();
        }

        public static List<WordModel> ToDto(this IEnumerable<Word> words)
        {
            return words.Select(w => w.ToDto()).ToList();
        }
    }
}