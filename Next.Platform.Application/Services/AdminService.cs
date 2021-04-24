using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
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

        public AdminService(IPlayGroundService playGroundService, IRepository<Admin> adminRepository, IMapper mapper, IAuthenticateService authenticateService)
        {
            this._adminRepository = adminRepository;
            this._mapper = mapper;
            this._playGroundService = playGroundService;
            this._authenticateService = authenticateService;
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
    }
}
