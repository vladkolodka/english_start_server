using System;
using System.Threading.Tasks;
using EnglishStartServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IActionResult> Index(Guid courseId, int padding, int count)
        {
            return Json(data: await _articleService.GetArticlesByCourse(GetUserId(), courseId, padding, count));
        }
    }
}