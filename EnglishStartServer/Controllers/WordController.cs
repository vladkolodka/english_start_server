using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishStartServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class WordController : ApiController
    {
        private readonly IWordService _service; 

        public WordController(IWordService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ForDictionary(Guid dictionaryId)
        {
            return Json(data: await _service.GetDictionaryWords(GetUserId(), dictionaryId));
        }

        public async Task<IActionResult> NotLearned(Guid dictionaryId, int count)
        {
            return Json(data: await _service.GetNotLearedWords(GetUserId(), dictionaryId, count));
        }

        [HttpPost]
        public async Task<IActionResult> SetStages([FromBody] IDictionary<Guid, int> data)
        {
            return Json(data: await _service.SetWordsStage(GetUserId(), data));
        }
    }
}