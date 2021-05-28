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
            RuleFor(a => a.Name).NotEmpty().WithMessage("no")
                .Matches(@"^(?=.{2,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$").WithMessage(
                    "Name should be like from 2 characters but no more than  20 characters and no no special characters digits allowed");
            RuleFor(x => x.Password)
                .Matches(@"^(?=.{2,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$").WithMessage("Name should be like from 2 characters but no more than  20 characters and no no special characters digits allowed");
        }
    }
}
