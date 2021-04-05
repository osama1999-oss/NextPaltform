using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;

namespace Next.Platform.Application.IServices
{
   public interface IOwnerService
   {
       string Login(OwnerAuthenticationDto ownerDto);
   }
}
