using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}