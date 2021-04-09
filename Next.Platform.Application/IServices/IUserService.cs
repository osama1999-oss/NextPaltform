﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
   public interface IUserService
   {
       string Login(UserAuthenticationDto user);
       Guid Register(UserModelDto user);
       public bool NumberIsUnique(string phoneNumber);
       Task<string> UploadImage(IFormFile imaFile, string folderName);
       string AddPhoneNumber(UserPhoneModelDto user);
       string CheckVerificationCode(VerificationCodeDto verificationCode);

   }
}
