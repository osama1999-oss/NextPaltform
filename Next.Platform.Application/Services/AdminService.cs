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
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        private readonly IPlayGroundService _playGroundService;
        private readonly IOwnerService _ownerService;

        public AdminService(IPlayGroundService playGroundService, IRepository<Admin> adminRepository, IOwnerService ownerService,
            IMapper mapper, IAuthenticateService authenticateService)
        {
            this._adminRepository = adminRepository;
            this._mapper = mapper;
            this._playGroundService = playGroundService;
            this._authenticateService = authenticateService;
            this._ownerService = ownerService;
        }
        public string Login(AdminAuthenticationDto adminDto)
        {
            var result = _adminRepository.FindBy(u => u.Name == adminDto.Name && u.Password == adminDto.Password)
                .FirstOrDefault();
            AdminAuthenticationDto admin = _mapper.Map<AdminAuthenticationDto>(result);
            return admin.Name;
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

        public List<OwnerInAdminViewModel> Get()
        {
          var result =   _ownerService.Get();
          List<OwnerInAdminViewModel> ownerInAdminViewModels = _mapper.Map<List<OwnerInAdminViewModel>>(result);
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
