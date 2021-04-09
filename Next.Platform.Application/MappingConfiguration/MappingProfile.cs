using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.MappingConfiguration
{
   public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserAuthenticationDto>();
            CreateMap<UserAuthenticationDto, User>();

            CreateMap<OwnerAuthenticationDto, Owner>();
            CreateMap<Owner, OwnerAuthenticationDto>();

            CreateMap<Admin, AdminAuthenticationDto>();

            CreateMap<UserModelDto, User>();
            CreateMap<OwnerModelDto, Owner>();


        }
    }
}
