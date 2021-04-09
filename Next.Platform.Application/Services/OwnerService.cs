using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
       private readonly IUserService _userService;
        public OwnerService(IUserService userService,IRepository<Owner> ownerRepository, IMapper mapper, 
            IAuthenticateService authenticateService)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
            this._userService = userService;
        }

        public string Login(OwnerAuthenticationDto ownerDto)
        {
            var result = _ownerRepository.FindBy(u => u.Email == ownerDto.Email && u.Password == ownerDto.Password)
                .FirstOrDefault();
            var owner = _mapper.Map<OwnerAuthenticationDto>(result);
            return owner.Email;
        }

        public bool Register(OwnerModelDto owner)
        {
            try
            {
                var result = _mapper.Map<Owner>(owner);
                result.Id = Guid.NewGuid();
                Task<string> imageName = UploadImage(owner.ImageFile);
                result.ImagePath = imageName.Result;
                _ownerRepository.Add(result);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool EmailIsUnique(string email)
        {
            Owner result = _ownerRepository.FindBy(u => u.Email == email).FirstOrDefault();
            if (result == null) return true; // mean this number not used
            return false;
        }

        public Task<string> UploadImage(IFormFile imageFile)
        {
          return  _userService.UploadImage(imageFile, "Owners");
        }
   }
}
