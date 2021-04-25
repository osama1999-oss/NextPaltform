using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Application.IServices
{
   public interface IAdminService
   {
       string Login(AdminAuthenticationDto adminDto);
       string PlaygroundApproval(PlayGroundRequestDto playGroundRequestDto);
       List<OwnerInAdminViewModel> Get();
       string BlockOwner(Guid id);
       string UnBlockOwner(Guid id);
   }
}
