using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class OwnerService :IOwnerService
   {
       private readonly IRepository<Owner> _ownerRepository;
       private readonly IAuthenticateService _authenticateService;
       private readonly IMapper _mapper;
        public OwnerService(IRepository<Owner> ownerRepository, IMapper mapper, IAuthenticateService authenticateService)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
        }

        public string Login(OwnerAuthenticationDto ownerDto)
        {
            var result = _ownerRepository.FindBy(u => u.Email == ownerDto.Email && u.Password == ownerDto.Password)
                .FirstOrDefault();
            var owner = _mapper.Map<OwnerAuthenticationDto>(result);
            return owner.Email;
        }
    }
}
