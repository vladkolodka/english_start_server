using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishStartServer.Database;
using EnglishStartServer.Dto;
using EnglishStartServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnglishStartServer.Services
{
    public class DictionaryService : BaseService, IDictionaryService
    {
        public DictionaryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<DictionaryModel>> SearchDictionaries(string searchQuery)
        {
            return (await Db.Dictionaries
                .Where(d => searchQuery.Contains(d.Name) || d.Name.Contains(searchQuery))
                .ToListAsync()).ToDto();
        }

        public async Task<List<WordModel>> AddWordsToDictionary(Guid userId, Guid dictionaryId, List<WordModel> words)
        {
            var dictionary = await Db.Dictionaries.Include(d => d.UserDictionaries)
                .FirstOrDefaultAsync(d => d.Id == dictionaryId &&
                                          d.UserDictionaries.Any(ad => ad.DictionaryId == dictionaryId &&
                                                                       ad.ApplicationUserId == userId && ad.IsOwner));

            if (dictionary == null) return null;

            // TODO dictionary.Words.Add(words.ToDto());

            await Db.SaveChangesAsync();

            return words;
        }
    }
}