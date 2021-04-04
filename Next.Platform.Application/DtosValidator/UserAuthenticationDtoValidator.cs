using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.DtosValidator
{
   public class UserAuthenticationDtoValidator: AbstractValidator<UserAuthenticationDto>
    {
        public UserAuthenticationDtoValidator()
        {
           RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumber is required");
           RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required");

        }
    }
}
