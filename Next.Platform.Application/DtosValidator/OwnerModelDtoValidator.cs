using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;

namespace Next.Platform.Application.DtosValidator
{
 public class OwnerModelDtoValidator:AbstractValidator<OwnerModelDto>
 {
     private readonly IOwnerService _ownerService;
        public OwnerModelDtoValidator(IOwnerService ownerService)
        {
            this._ownerService = ownerService;
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Name is required")
                .Matches(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})(\w ?)+[a-zA-Z0-9._]+(?<![_.])$").WithMessage(
                    "Name should be like from 8 characters but no more than  20 characters and no no special characters digits allowed");

            RuleFor(u => u.Location).NotEmpty().NotNull().WithMessage("Location is required");

            RuleFor(u => u.Email).NotEmpty().NotNull().WithMessage("Email is required ")
                .Matches(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Email Should be in the right Like example@example.com")
                .Must((OwnerModelDto, Email)=> EmailIsUnique(Email)).WithMessage("This Email already in use");

            RuleFor(u => u.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumber is required")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Phone Number should be like in Phone length is exactly 11 And Phone Prefix is with in allowed ones 010, 011, 012, 015");

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required")
                .Matches(@"^(?=.*[0-9]).{8,12}$").WithMessage("Password should be less than 8 characters  but no more than 12 and at at least one digit");


            RuleFor(x => x.RePassword).NotNull().NotEmpty().WithMessage("Password is required")
                .Matches(@"^(?=.*[0-9]).{8,12}$")
                .WithMessage("Password should be less than 8 characters  but no more than 12 and at at least one digit")
                .Must((UserModelDto, RePassword) => IsEqual(UserModelDto.Password, RePassword))
                .WithMessage("Password should match RePassword");
        }
        private bool IsEqual(string password, string rePassword)
        {
            return password == rePassword;
        }

        private bool EmailIsUnique(string email)
        {
            return _ownerService.EmailIsUnique(email);
        }
    }
}
