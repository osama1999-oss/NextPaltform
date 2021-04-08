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
        public UserService(IWebHostEnvironment hostEnvironment,IRepository<User> useRepository, IMapper mapper, IAuthenticateService authenticateService)
        {
            this._userRepository = useRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
            this._hostEnvironment = hostEnvironment;
        }

        public string Login(UserAuthenticationDto userDto)
        {
             var result= _userRepository.FindBy(u => u.PhoneNumber == userDto.PhoneNumber && u.Password == userDto.Password)
                    .FirstOrDefault();
             string token = null;
             if(result != null)
             {
                 var userDtoResult = _mapper.Map<UserAuthenticationDto>(result);
                  token = _authenticateService.GenerateJSONWebToken(result.Name);
             }

            return token;
        }

        public bool Register(UserModelDto user)
        {
            try
            {
                var result = _mapper.Map<User>(user);
                result.Id=Guid.NewGuid();
                Task<string> imageName = UploadImage(user.ImageFile);
                result.ImagePath = imageName.Result;
                _userRepository.Add(result);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
       
        }
        public bool IsUnique(string phoneNumber)
        {
            User result = _userRepository.FindBy(u => u.PhoneNumber == phoneNumber).FirstOrDefault();
            if (result == null) return true; // mean this number not used
            return false;
        }
        public  async Task<string> UploadImage(IFormFile imageFile)
        {
            if (imageFile == null)
            {
                return "DefaultImage.png";
            }

            string wwwRootPath = _hostEnvironment.WebRootPath;  
            string fileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string extension = Path.GetExtension(imageFile.FileName);
            string imageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "\\Images\\", imageName);
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

    }
}
