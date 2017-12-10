using System;
using System.Threading.Tasks;
using EnglishStartServer.Dto;
using EnglishStartServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class DictionaryController : ApiController
    {
        private readonly IDictionaryService _service;

        public DictionaryController(IDictionaryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DictionaryModel data)
        {
            return Json(data: await _service.CreateDictionary(GetUserId(), data));
        }

        public async Task<IActionResult> Add(Guid dictionaryId)
        {
            return Json(data: await _service.AssignDictionary(GetUserId(), dictionaryId));
        }

        public async Task<IActionResult> Own()
        {
            return Json(data: await _service.GetUserDictionaries(GetUserId()));
        }

        public async Task<IActionResult> Search(string data)
        {
            return Json(data: await _service.SearchDictionaries(data));
        }

        public async Task<IActionResult> SetStatus(Guid dictionaryId, bool status = true)
        {
            return Json(data: await _service.SetDictionaryLearnStatus(GetUserId(), dictionaryId, status));
        }

        public async Task<IActionResult> Archive(Guid dictionaryId, bool archived = true)
        {
            return Json(data: await _service.ArchiveDictionary(GetUserId(), dictionaryId, archived));
        }

        [HttpPost]
        public async Task<IActionResult> AddWords([FromBody] AddWordsModel data)
        {
            return Json(data: await _service.AddWordsToDictionary(GetUserId(), data.DictionaryId, data.Words));
        }
    }
}