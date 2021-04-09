﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.IServices
{
   public interface IOwnerService
   {
       string Login(OwnerAuthenticationDto ownerDto);
       bool Register(OwnerModelDto owner);
       public bool EmailIsUnique(string email);
       Task<string> UploadImage(IFormFile imaFile);
    }
}
