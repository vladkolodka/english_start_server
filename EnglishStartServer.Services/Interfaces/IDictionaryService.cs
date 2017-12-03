using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<DictionaryModel>> SearchDictionaries(string searchQuery);
        Task<List<WordModel>> AddWordsToDictionary(Guid userId, Guid dictionaryId, List<WordModel> wordModels);
        Task<DictionaryModel> CreateDictionary(Guid userId, DictionaryModel dictionaryModel);
        Task<bool> AssignDictionary(Guid userId, Guid dictionaryId);
        Task<bool> ArchiveDictionary(Guid userId, Guid dictionaryId, bool archived = true);
        Task<bool> SetDictionaryLearnStatus(Guid userId, Guid dictionaryId, bool status);
        Task<List<DictionaryModel>> GetUserDictionaries(Guid userId);
    }
}