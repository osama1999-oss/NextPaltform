using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class UserService : IUserService
   {
       private readonly IRepository<User> _userRepository;
       private readonly IAuthenticateService _authenticateService;
       private readonly IMapper _mapper;
       private readonly IWebHostEnvironment _hostEnvironment;
       private readonly IVerificationService _verificationService;
        public UserService(IWebHostEnvironment hostEnvironment, IVerificationService verificationService,
            IRepository<User> useRepository, IMapper mapper, IAuthenticateService authenticateService)
        {
            this._userRepository = useRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
            this._hostEnvironment = hostEnvironment;
            this._verificationService = verificationService;
        }

        public string Login(UserAuthenticationDto userDto)
        {
             var result= _userRepository.FindBy(u => u.PhoneNumber == userDto.PhoneNumber && u.Password == userDto.Password && u.IsVerified == true)
                    .FirstOrDefault();
             string token = null;
             if(result != null)
             {
                 var userDtoResult = _mapper.Map<UserAuthenticationDto>(result);
                  token = _authenticateService.GenerateJSONWebToken(result.Name);
             }

            return token;
        }
        public Guid Register(UserModelDto user)
        {
            try
            {
                // user => phone number 
                var result = _mapper.Map<User>(user);
                result.Id=Guid.NewGuid();
                Task<string> imageName = UploadImage(user.ImageFile, "Users");
                result.ImagePath = imageName.Result;
                _userRepository.Add(result);
                return result.Id;
            }

            catch (Exception e)
            {
                throw;
            }
       
        }
        public bool NumberIsUnique(string phoneNumber)
        {
            User result = _userRepository.FindBy(u => u.PhoneNumber == phoneNumber).FirstOrDefault();
            if (result == null) return true; // mean this number not used
            return false;
        }
        public  async Task<string> UploadImage(IFormFile imageFile , string folderName)
        {
            if (imageFile == null)
            {
                return "DefaultImage.png";
            }

            string wwwRootPath = _hostEnvironment.WebRootPath;  
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string imageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "\\Images\\" + folderName +"\\", imageName);
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                  await  imageFile.CopyToAsync(fileStream);
                }
            }
            catch (Exception e)
            {
                throw ;
                return "DefaultImage.png";
            }

            return imageName;

        }
        public string AddPhoneNumber(UserPhoneModelDto user)
        {
            User result = _userRepository.FindBy(u => u.Id == user.Id).FirstOrDefault();
            result.PhoneNumber = user.PhoneNumber;
            _userRepository.Edit(result);
            string phoneNumber = _verificationService.NumberToInternationalFormat(result.PhoneNumber);
            string status =  _verificationService.SendVerificationCode(phoneNumber);
            if (status == "pending")
                return result.Id.ToString();
            return null;
        }
        public string CheckVerificationCode(VerificationCodeDto verificationCode)
        {
            User user = _userRepository.FindBy(u => u.Id == verificationCode.Id).FirstOrDefault();
            string phoneNumber =   _verificationService.NumberToInternationalFormat(user.PhoneNumber);
            string status =  _verificationService.CheckVerificationCode(phoneNumber, verificationCode.Code);
            if (status == "approved")
            {
                user.IsVerified = true;
                _userRepository.Edit(user);
            }
                
            return status;
        }
   }
}
