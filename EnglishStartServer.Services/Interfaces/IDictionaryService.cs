using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<DictionaryModel>> SearchDictionaries(string searchQuery);
        Task<List<WordModel>> AddWordsToDictionary(Guid userId, Guid dictionaryId, List<WordModel> words);
        Task<DictionaryModel> CreateDictionary(Guid userId, DictionaryModel dictionaryModel);
        Task<bool> AssignDictionary(Guid userId, Guid dictionaryId);
    }
}