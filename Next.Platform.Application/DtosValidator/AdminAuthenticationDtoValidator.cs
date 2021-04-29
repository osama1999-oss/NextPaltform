using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.DtosValidator
{
   public class AdminAuthenticationDtoValidator:AbstractValidator<AdminAuthenticationDto>
    {
        public AdminAuthenticationDtoValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("Name is required")
                .Matches(@"^(?=.{2,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$").WithMessage(
                    "Name should be like from 2 characters but no more than  20 characters and no no special characters digits allowed");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required")
                .Matches(@"^(?=.*[0-9]).{2,12}$").WithMessage("Password should be less than 2 characters  but no more than 12 and at at least one digit");
        }
    }
}
