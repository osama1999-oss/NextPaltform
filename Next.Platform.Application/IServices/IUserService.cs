using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
   public interface IUserService
   {
       UserAuthenticationDto Login(UserAuthenticationDto user);
   }
}
