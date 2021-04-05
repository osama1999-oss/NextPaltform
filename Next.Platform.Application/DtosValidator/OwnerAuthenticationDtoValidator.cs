using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.DtosValidator
{
  public  class OwnerAuthenticationDtoValidator :AbstractValidator<OwnerAuthenticationDto>
    {
        public OwnerAuthenticationDtoValidator()
        {
            RuleFor(o => o.Email).NotEmpty().NotNull().WithMessage("Email is required ")
                .Matches(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Email Should be in the right Like example@example.com");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required")
                .Matches(@"^(?=.*[0-9]).{8,12}$").WithMessage("Password should be less than 8 characters  but no more than 12 and at at least one digit");
        }
    }
}
