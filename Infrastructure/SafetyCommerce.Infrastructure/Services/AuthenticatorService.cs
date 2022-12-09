using Microsoft.AspNetCore.Identity;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Infrastructure.Services
{
    public class AuthenticatorService:IAuthenticatorService
    {
        UserManager<AppUser> _userManager;

        public AuthenticatorService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GenerateSharedKey(AppUser user)
        {
            string sharedkey=await _userManager.GetAuthenticatorKeyAsync(user);
            if (!string.IsNullOrEmpty(sharedkey))
            {
                IdentityResult result=await _userManager.ResetAuthenticatorKeyAsync(user);
                if (result.Succeeded)
                {
                    sharedkey = await _userManager.GetAuthenticatorKeyAsync(user);
                }
            }
            return sharedkey;
        }
        public async Task<VerifyState> Verify(AuthenticatorVM model, AppUser user)
        {
            VerifyState verifyState = new VerifyState();
            verifyState.State = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, model.VerificationCode);
            if (verifyState.State)
            {
                user.TwoFactorEnabled = true;
                
            }
            return verifyState;
        }
    }
}
