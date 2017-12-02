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
    public class WordService : BaseService, IWordService
    {
        public WordService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> SetWordsStage(Guid userId, IDictionary<Guid, int> wordChanges)
        {
            var words = await Db.Words.Where(w => wordChanges.ContainsKey(w.Id)).ToListAsync();

            // check if all specified word ids exist
            if (!words.Any() || wordChanges.Count != words.Count) return false;

            var dictionaryId = words[0].DictionaryId;

            // check if all words from one dictionary
            if (words.All(w => w.DictionaryId == dictionaryId)) return false;

            var userDictionary = Db.ApplicationUserDictionary.FirstOrDefaultAsync(d =>
                d.DictionaryId == dictionaryId && d.ApplicationUserId == userId);

            // check that user learns dictionary
            if (userDictionary == null) return false;

            var userWords = await Db.ApplicationUserWords.Where(aw => aw.ApplicationUserId == userId &&
                                                                      wordChanges.ContainsKey(aw.WordId)).ToListAsync();

            userWords.AddRange(wordChanges.Select(pair => pair.Key).Except(userWords.Select(aw => aw.WordId))
                .Select(wordId => new ApplicationUserWord
                {
                    WordId = wordId,
                    ApplicationUserId = userId
                }));

            userWords.ForEach(w =>
            {
                if (wordChanges[w.WordId] > 0) w.Stage++;
                else w.Stage--;
            });

            await Db.SaveChangesAsync();

            return true;
        }

        public async Task<List<WordModel>> GetDictionaryWords(Guid userId, Guid dictionaryId)
        {
            var words = await Db.Words.Where(w => w.DictionaryId == dictionaryId).ToListAsync();
            var wordIds = words.Select(w => w.Id);

            var userWords = await Db.ApplicationUserWords.Where(aw =>
                    aw.ApplicationUserId == userId && wordIds.Contains(aw.WordId))
                .ToDictionaryAsync(aw => aw.WordId, aw => aw.Stage);

            foreach (var wordId in wordIds.Except(userWords.Keys)) userWords.Add(wordId, 0);

            return words.ToDto(userWords);
        }

        public async Task<List<WordModel>> GetUserWordsWithStage(Guid userId, Guid dictionaryId, int stage, int count)
        {
            var ignoredIds = await Db.ApplicationUserWords
                .Where(aw => aw.ApplicationUserId == userId && aw.Stage != stage)
                .Select(aw => aw.WordId).ToListAsync();

            return (await Db.Words.Where(w => w.DictionaryId == dictionaryId && !ignoredIds.Contains(w.Id))
                    .OrderBy(w => w.Original).Take(count)
                    .ToListAsync())
                .ToDto(stage);
        }
    }
}