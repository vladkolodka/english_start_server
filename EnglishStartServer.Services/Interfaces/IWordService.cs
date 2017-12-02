using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IWordService
    {
        Task<bool> SetWordsStage(Guid userId, IDictionary<Guid, int> wordChanges);
        Task<List<WordModel>> GetDictionaryWords(Guid userId, Guid dictionaryId);
        Task<List<WordModel>> GetUserWordsWithStage(Guid userId, Guid dictionaryId, int stage, int count);
    }
}