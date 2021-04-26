using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.DtosValidator;

namespace Next.Platform.Application.Configuration
{
  public  static class RegisterValidator
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IValidator<UserAuthenticationDto>, UserAuthenticationDtoValidator>();
            services.AddTransient<IValidator<OwnerAuthenticationDto>, OwnerAuthenticationDtoValidator>();
            services.AddTransient<IValidator<AdminAuthenticationDto>, AdminAuthenticationDtoValidator>();
            services.AddTransient<IValidator<MemberModelDto>, MemberModelDtoValidator>();
            services.AddTransient<IValidator<PlayGroundDto>, PlayGroundDtoValidator>();
            services.AddTransient<IValidator<PlayGroundCategoryDto>, PlayGroundCategoryDtoValidator>();
        }
    }
}
