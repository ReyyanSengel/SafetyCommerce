using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginViewModel);
            }
            var LoginResult = await _signInManager.PasswordSignInAsync(userLoginViewModel.UserName, userLoginViewModel.Password, true, true);

            if (!LoginResult.Succeeded)
            {
                ModelState.AddModelError("Not user", "Wrong username or password");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
