using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class ArticlesController : ApiController
    {
        public IActionResult Test()
        {
            return Json("Test");
        }
    }
}