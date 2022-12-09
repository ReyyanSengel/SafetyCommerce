using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterViewModel);
            }

            AppUser appUser = new AppUser()
            {
                Name = userRegisterViewModel.Name,
                SurName = userRegisterViewModel.SurName,
                UserName = userRegisterViewModel.UserName,
                Email = userRegisterViewModel.Email
            };

            var RegisterResult = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);

            if (!RegisterResult.Succeeded)
            {
                foreach (var item in RegisterResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return RedirectToAction("Index", "Login");










        
    }
}
}
