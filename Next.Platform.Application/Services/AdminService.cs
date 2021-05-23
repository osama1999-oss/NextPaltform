using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
  public  class AdminService : IAdminService
    {
        private readonly IRepository<Admin> _adminRepository;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IPlayGroundService _playGroundService;
        private readonly IOwnerService _ownerService;
        private readonly IUserService _userService;

        public AdminService(IUserService userService,IPlayGroundService playGroundService, IRepository<Admin> adminRepository, IOwnerService ownerService,
            IMapper mapper, ICommonService commonService)
        {
            this._adminRepository = adminRepository;
            this._mapper = mapper;
            this._playGroundService = playGroundService;
            this._commonService = commonService;
            this._ownerService = ownerService;
            this._userService = userService;
        }
        public string Login(AdminAuthenticationDto adminDto)
        {
            Admin result = _adminRepository.FindBy(u => u.Name == adminDto.Name && u.Password == adminDto.Password)
                .FirstOrDefault();
            if (result == null)
                return "unauthorized";
            return result.Id.ToString();
        }

        public string PlaygroundApproval(PlayGroundRequestDto playGroundRequestDto)
        {
         var result =  _playGroundService.GetById(playGroundRequestDto.Id);
         if(playGroundRequestDto.Status)
             result.PlayGroundStatusId = PlayGroundStatusEnum.Approved;
         else
             result.PlayGroundStatusId = PlayGroundStatusEnum.Canceled;
         _playGroundService.Save(result);
         return result.PlayGroundStatusId.ToString();
        }

        public List<OwnerInAdminViewModel> GetOwners()
        {
          var result =   _ownerService.Get().Where(o => o.MemberStatusId == MemberStatusEnum.Available);
          List<OwnerInAdminViewModel> ownerInAdminViewModels = _mapper.Map<List<OwnerInAdminViewModel>>(result);

            foreach (var owner in ownerInAdminViewModels)
            {
                owner.Location = _commonService.GetNeighborhood(owner.NeighborhoodId);
            }
          return ownerInAdminViewModels;

        }

        public List<UserInAdminViewModel> GetUsers()
        {
          var result=  _userService.Get();
         
          return result;

        }

        public List<OwnerInAdminViewModel> GetBlockedOwners()
        {
            var results= _ownerService.Get().Where(o => o.MemberStatusId == MemberStatusEnum.Blocked).ToList();
            List<OwnerInAdminViewModel> ownerInAdminViewModels = _mapper.Map<List<OwnerInAdminViewModel>>(results);

            foreach (var owner in ownerInAdminViewModels)
            {
                owner.Location = _commonService.GetNeighborhood(owner.NeighborhoodId);
            }
            return ownerInAdminViewModels;
        }

        public string BlockOwner(Guid id)
        {
         Owner owner =   _ownerService.GetById(id);
         owner.MemberStatusId = MemberStatusEnum.Blocked;
         _ownerService.Save(owner);
         return owner.MemberStatusId.ToString();
        }

        public string UnBlockOwner(Guid id)
        {
            Owner owner = _ownerService.GetById(id);
            owner.MemberStatusId = MemberStatusEnum.Available;
            _ownerService.Save(owner);
            return owner.MemberStatusId.ToString();
        }
    }
}
