using FluentValidation;
using SafetyCommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.Validations
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.SurName)
                .NotNull()
                .NotEmpty()
                .WithMessage("SurName is required");

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("UserName is required");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress().WithMessage("You must enter an email address");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Please enter the password");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Please enter the confirmation password");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.Password), "Passwords should match");
                }
            });
        }
    }
}
