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
       private readonly IVerificationService _verificationService;

        public OwnerService(IUserService userService,IRepository<Owner> ownerRepository, IMapper mapper, IVerificationService verificationService,
            IAuthenticateService authenticateService)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
            this._userService = userService;
            this._verificationService = verificationService;

        }

        public string Login(OwnerAuthenticationDto ownerDto)
        {
            var result = _ownerRepository.FindBy(u => u.Email == ownerDto.Email && u.Password == ownerDto.Password && u.IsVerified == true)
                .FirstOrDefault();
            var owner = _mapper.Map<OwnerAuthenticationDto>(result);
            return owner.Email;
        }

        public string Register(MemberModelDto owner)
        {
            try
            {
                if (EmailIsUnique(owner.Email))
                {
                    var result = _mapper.Map<Owner>(owner);
                    result.Id = Guid.NewGuid();
                    Task<string> imageName = UploadImage(owner.ImageFile);
                    result.ImagePath = imageName.Result;
                    _ownerRepository.Add(result);
                    return result.Id.ToString();
                }
                return "This Email Already In Use";
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
        public string AddPhoneNumber(PhoneModelDto owner)
        {
            if (!_userService.NumberIsUnique(owner.PhoneNumber))
                return "This Number Already In USe";

            Owner result = _ownerRepository.FindBy(u => u.Id == owner.Id).FirstOrDefault();
            result.PhoneNumber = owner.PhoneNumber;
            _ownerRepository.Edit(result);
            string phoneNumber = _verificationService.NumberToInternationalFormat(result.PhoneNumber);
            string status = _verificationService.SendVerificationCode(phoneNumber);
            if (status == "pending")
                return result.Id.ToString();
            return "We have problem to send Verification Code";
        }
        public string CheckVerificationCode(VerificationCodeDto verificationCode)
        {
            Owner owner = _ownerRepository.FindBy(u => u.Id == verificationCode.Id).FirstOrDefault();
            string phoneNumber = _verificationService.NumberToInternationalFormat(owner.PhoneNumber);
            string status = _verificationService.CheckVerificationCode(phoneNumber, verificationCode.Code);
            if (status == "approved")
            {
                owner.IsVerified = true;
                _ownerRepository.Edit(owner);
            }

            return status;
        }
    }
}
