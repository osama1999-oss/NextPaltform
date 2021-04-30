﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
   public interface IUserService
   {

       List<PlayGroundReservationsViewModel> GetCurrentReservations(Guid UserId);
       List<PlayGroundReservationsViewModel> GetReservationsHistory(Guid UserId);
       string Login(UserAuthenticationDto user);
       string Register(MemberModelDto user);
       public bool NumberIsUnique(string phoneNumber);
       string UploadImage(IFormFile imaFile, string folderName);
       string AddPhoneNumber(PhoneModelDto user);
       string CheckVerificationCode(VerificationCodeDto verificationCode);
       List<UserInAdminViewModel> Get();

   }
}
