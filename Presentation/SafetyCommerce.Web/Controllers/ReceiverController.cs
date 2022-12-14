using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;
using SafetyCommerce.Infrastructure.Services;

namespace SafetyCommerce.Web.Controllers
{
    [AllowAnonymous]
    public class ReceiverController : Controller
    {
        private readonly IReceiverAppService _receiverAppService;
        private readonly IMapper _mapper;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly UserManager<AppUser> _userManager;

        public ReceiverController(IReceiverAppService receiverAppService, IMapper mapper, IAuthenticatorService authenticatorService, UserManager<AppUser> userManager)
        {
            _receiverAppService = receiverAppService;
            _mapper = mapper;
            _authenticatorService = authenticatorService;
            _userManager = userManager;
        }

        public IActionResult ReceiverApp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReceiverApp(ReceiverAppVM receiver)
        {
            await _receiverAppService.AddAsync(_mapper.Map<ReceiverApp>(receiver));
            return View();
        }

        public IActionResult Information()
        {
            
            return View();
        }

        public async Task<IActionResult> ReceiverAuthenticatorVerify()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string sharedKey = await _authenticatorService.GenerateSharedKey(appUser);
            return View(new AuthenticatorVM
            {
                SharedKey = sharedKey
            });
        }

        [HttpPost]
        public async Task<IActionResult> ReceiverAuthenticatorVerify(AuthenticatorVM model)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            VerifyState verifyState = await _authenticatorService.Verify(model, user);
            if (verifyState.State)
            {
                user.TwoFactorEnabled = true;
            }
            return View(model);

        }

        public IActionResult Message()
        {
            return View();
        }
    }
}
