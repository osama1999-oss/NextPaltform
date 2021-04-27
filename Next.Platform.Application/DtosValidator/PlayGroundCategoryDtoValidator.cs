using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentValidation;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.DtosValidator
{
  public class PlayGroundCategoryDtoValidator:AbstractValidator<PlayGroundCategoryDto>
    {
        public PlayGroundCategoryDtoValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Name is required")
                .Matches(@"^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})(\w ?)+[a-zA-Z0-9._]+(?<![_.])$").WithMessage(
                    "Name should be like from 3 characters but no more than  20 characters and no no special characters digits allowed");
            RuleFor(u => u.Price).NotNull().NotEmpty().WithMessage("Price is required");
        }
    }
}
