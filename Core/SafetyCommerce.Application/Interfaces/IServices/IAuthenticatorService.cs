using SafetyCommerce.Application.ViewModels;
using SafetyCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.Interfaces.IServices
{
    public interface IAuthenticatorService
    {
        Task<string> GenerateSharedKey(AppUser user);
        Task<VerifyState> Verify(AuthenticatorVM model, AppUser user);
    }
}
