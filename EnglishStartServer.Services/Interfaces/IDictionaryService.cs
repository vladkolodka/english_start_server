using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto;

namespace EnglishStartServer.Services.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<DictionaryModel>> SearchDictionaries(string searchQuery);
        Task<List<WordModel>> AddWordsToDictionary(Guid userId, Guid dictionaryId, List<WordModel> words);
    }
}