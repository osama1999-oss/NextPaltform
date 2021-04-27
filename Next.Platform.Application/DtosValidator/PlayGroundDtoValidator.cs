using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.DtosValidator
{
  public class PlayGroundDtoValidator :AbstractValidator<PlayGroundDto>
    {
        public PlayGroundDtoValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Name is required")
                .Matches(@"^(?=.{3,30}$)(?![_.])(?!.*[_.]{2})(\w ?)+[a-zA-Z0-9._]+(?<![_.])$").WithMessage(
                    "Name should be like from 3 characters but no more than  20 characters and no no special characters digits allowed");

            RuleFor(u => u.From).NotNull().NotEmpty().WithMessage("From is required");
            RuleFor(u => u.To).NotNull().NotEmpty().WithMessage("To is required");
            RuleFor(u => u.PriceEvening).NotNull().NotEmpty().WithMessage("PriceEvening is required");
            RuleFor(u => u.PriceMorning).NotNull().NotEmpty().WithMessage("PriceMorning is required");
            RuleFor(u => u.PlayGroundTypeId).NotNull().NotEmpty().WithMessage("Type is required");

        }
    }
}
