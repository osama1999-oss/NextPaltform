using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;
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

            CreateMap<MemberModelDto, User>();
            CreateMap<MemberModelDto, Owner>();

            CreateMap<PlayGroundDto, PlayGround>();
            CreateMap<Owner, OwnerInAdminViewModel>()
                .ForMember(dest => dest.Status,source => source.MapFrom(src => src.MemberStatusId));


        }
    }
}
