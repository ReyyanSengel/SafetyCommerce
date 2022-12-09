﻿using FluentValidation;
using SafetyCommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.Validations
{
    public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("UserName is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please enter the password");
        }
    }
}
