using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;

namespace Next.Platform.Application.DtosValidator
{
    class PhoneModelDtoValidator : AbstractValidator<PhoneModelDto>
    {
        private readonly IUserService _userService;
        PhoneModelDtoValidator(IUserService userService)
        {
            this._userService = userService;
            RuleFor(u => u.Id).NotEmpty().NotNull();
            RuleFor(u => u.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumber is required")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage(
                    "Phone Number should be like in Phone length is exactly 11 And Phone Prefix is with in allowed ones 010, 011, 012, 015");

        }

        
    }
}
