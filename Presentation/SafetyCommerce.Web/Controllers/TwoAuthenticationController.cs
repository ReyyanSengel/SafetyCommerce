using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class TwoAuthenticationController : Controller
    {
        private readonly IAuthenticatorService _authenticatorService;
        private readonly UserManager<AppUser> _userManager;

        public TwoAuthenticationController(IAuthenticatorService authenticatorService, UserManager<AppUser> userManager)
        {
            _authenticatorService = authenticatorService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AuthenticatorVerify()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string sharedKey=await _authenticatorService.GenerateSharedKey(appUser);
            return View(new AuthenticatorVM
            {
                SharedKey = sharedKey
            });
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticatorVerify(AuthenticatorVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            VerifyState verifyState = await _authenticatorService.Verify(model, user);
            if (verifyState.State)
            {
                user.TwoFactorEnabled = true;
            }
            return View(model);

        }

       
    }
}
