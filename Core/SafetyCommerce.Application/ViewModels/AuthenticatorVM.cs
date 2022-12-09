using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.ViewModels
{
    public class AuthenticatorVM
    {
        public string SharedKey { get; set; }
        public string VerificationCode { get; set; }
    }
}
