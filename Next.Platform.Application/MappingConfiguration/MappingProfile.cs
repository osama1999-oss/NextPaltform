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

            CreateMap<User, UserInAdminViewModel>();
            CreateMap<PlayGroundCategoryDto, PlayGroundCategory>();
            CreateMap<PlayGroundCategory, PlayGroundCategoriesViewModel>();
            CreateMap<PlayGround, PlayGroundListViewModel>()
                .ForMember(dest => dest.Status, source => source.MapFrom(src => src.PlayGroundStatusId))
                .ForMember(type => type.Type, source => source.MapFrom(src => src.PlayGroundTypeId));
          
            CreateMap<PlayGround, PlayGroundViewModel>()
                .ForMember(dest => dest.Status, source => source.MapFrom(src => src.PlayGroundStatusId));
            CreateMap<PlayGroundBooking, PlayGroundReservationsViewModel>()
                .ForMember(dest => dest.Status, source => source.MapFrom(src => src.PlayGroundBookingStatusId));

            CreateMap<PlayGroundType, PlayGroundsTypesViewModel>();
            CreateMap<Neighborhood, NeighborhoodViewModel>();
            CreateMap<ReserveDto, PlayGroundBooking>();
            CreateMap<PreferredDto, PreferredPlayGround>();
        }
    }
}
