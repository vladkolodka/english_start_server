using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishStartServer.Database;
using EnglishStartServer.Database.Models;
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
            // TODO throw exception
            if (dictionary == null) return null;

            // TODO dictionary.Words.Add(words.ToDto());

            await Db.SaveChangesAsync();

            return words;
        }

        public async Task<DictionaryModel> CreateDictionary(Guid userId, DictionaryModel dictionaryModel)
        {
            var language = await Db.Languages.FirstOrDefaultAsync(l => l.Name.Equals(dictionaryModel.SourceLanguage));

            // TODO throw exception
            if (language == null) return null;

            var dictionary = dictionaryModel.ToEntity(language);

            dictionary.UserDictionaries.Add(new ApplicationUserDictionary
            {
                ApplicationUserId = userId,
                IsOwner = true,
                IsStudied = false
            });

            await Db.Dictionaries.AddAsync(dictionary);

            await Db.SaveChangesAsync();
            return dictionary.ToDto();
        }

        public async Task<bool> AssignDictionary(Guid userId, Guid dictionaryId)
        {
            if (await
                Db.ApplicationUserDictionary.AnyAsync(ad =>
                    ad.ApplicationUserId == userId && ad.DictionaryId == dictionaryId))
                return false;

            var dictionary = await Db.Dictionaries.FirstOrDefaultAsync(d => d.Id == dictionaryId);

            // TODO throw exception
            if (dictionary == null) return false;

            await Db.ApplicationUserDictionary.AddAsync(new ApplicationUserDictionary
            {
                Dictionary = dictionary,
                ApplicationUserId = userId
            });

            await Db.SaveChangesAsync();
            return true;
        }
    }
}