using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;

namespace Next.Platform.Application.IServices
{
   public interface IOwnerService
   {
       List<PlayGroundReservationsViewModel> GetReservationRequest(Guid ownerId);
       string Login(OwnerAuthenticationDto ownerDto);
       string Register(MemberModelDto owner);
       public bool EmailIsUnique(string email);
       string UploadImage(IFormFile imaFile);
       string AddPhoneNumber(PhoneModelDto user);
       string CheckVerificationCode(VerificationCodeDto verificationCode);
       bool NumberIsUnique(string phoneNumber);
       List<Owner> Get();
       Owner GetById(Guid id);
       void Save(Owner owner);
       bool IfBlocked(Guid ownerId);
   }
}
