using System.Threading.Tasks;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EnglishStartServer.Controllers
{
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            // TODO jwt

            return (await _signInManager.PasswordSignInAsync(data.Login, data.Password, true, false)).Succeeded
                ? Json(data: (await _userManager.FindByNameAsync(data.Login)).ToDto())
                : Json(401, "", "Unauthorized");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] LoginModel data)
        {
            return (await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = data.Login
            }, data.Password)).Succeeded
                ? await Login(data)
                : Json(406, "", "Not acceptable");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Json<string>();
        }

        [HttpGet]
        public async Task<IActionResult> WhoAmI()
        {
            return Json(data: (await _userManager.GetUserAsync(User)).ToDto());
        }
    }
}