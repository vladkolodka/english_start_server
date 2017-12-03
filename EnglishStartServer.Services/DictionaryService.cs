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
                .Select(d => d.ToDto(false))
                .ToListAsync());
        }

        public async Task<List<WordModel>> AddWordsToDictionary(Guid userId, Guid dictionaryId,
            List<WordModel> wordModels)
        {
            var dictionary = await Db.Dictionaries.Include(d => d.UserDictionaries)
                .FirstOrDefaultAsync(d => d.Id == dictionaryId &&
                                          d.UserDictionaries.Any(ad => ad.ApplicationUserId == userId && ad.IsOwner));
            // TODO throw exception
            if (dictionary == null) return null;

            var words = wordModels.ToEntity();

            dictionary.Words.AddRange(words);

            await Db.SaveChangesAsync();

            return words.ToDto(0);
        }

        public async Task<DictionaryModel> CreateDictionary(Guid userId, DictionaryModel dictionaryModel)
        {
            var language = await Db.Languages.FirstOrDefaultAsync(l => l.Name.Equals(dictionaryModel.SourceLanguage));

            var dictionary = dictionaryModel.ToEntity(language ?? new Language
            {
                Name = dictionaryModel.SourceLanguage
            });

            dictionary.UserDictionaries.Add(new ApplicationUserDictionary
            {
                ApplicationUserId = userId,
                IsOwner = true,
                IsStudied = false
            });

            await Db.Dictionaries.AddAsync(dictionary);

            await Db.SaveChangesAsync();
            return dictionary.ToDto(false);
        }

        public async Task<bool> AssignDictionary(Guid userId, Guid dictionaryId)
        {
            if (await
                Db.ApplicationUserDictionary.AnyAsync(ad =>
                    ad.ApplicationUserId == userId && ad.DictionaryId == dictionaryId))
                return false;

            var dictionary = await Db.Dictionaries.FirstOrDefaultAsync(d => d.Id == dictionaryId && d.IsPublic);

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

        public async Task<bool> ArchiveDictionary(Guid userId, Guid dictionaryId, bool archived = true)
        {
            var userDictionary = await
                Db.ApplicationUserDictionary.FirstOrDefaultAsync(ud => ud.DictionaryId == dictionaryId &&
                                                                       ud.ApplicationUserId == userId);
            if (userDictionary == null) return false;

            userDictionary.IsArchived = archived;

            await Db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetDictionaryLearnStatus(Guid userId, Guid dictionaryId, bool status)
        {
            var userDictionary = await
                Db.ApplicationUserDictionary.FirstOrDefaultAsync(ad =>
                    ad.ApplicationUserId == userId && ad.DictionaryId == dictionaryId);

            if (userDictionary == null) return false;

            userDictionary.IsStudied = status;

            await Db.SaveChangesAsync();
            return true;
        }

        public async Task<List<DictionaryModel>> GetUserDictionaries(Guid userId)
        {
            return (await Db.ApplicationUserDictionary.Include(ad => ad.Dictionary)
                .Where(ad => ad.ApplicationUserId == userId).Select(ad => ad.Dictionary.ToDto(ad.IsStudied))
                .ToListAsync());
        }
    }
}