using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class OwnerService :IOwnerService
   {
       private readonly IRepository<Owner> _ownerRepository;
       private readonly IMapper _mapper;
       private readonly IVerificationService _verificationService;
       private readonly ICommonService _commonService;
       private readonly IPlayGroundBookingService _bookingService;


        public OwnerService(ICommonService commonService, IRepository<Owner> ownerRepository,
            IMapper mapper, IVerificationService verificationService, IPlayGroundBookingService bookingService)
        {
            this._ownerRepository = ownerRepository;
            this._mapper = mapper;
            this._verificationService = verificationService;
            this._commonService = commonService;
            this._bookingService = bookingService;
        }

        public List<PlayGroundReservationsViewModel> GetReservationRequest(Guid ownerId)
        {
            var result = GetById(ownerId);
            return null;

        }

        public string Login(OwnerAuthenticationDto ownerDto)
        {
            var result = _ownerRepository.FindBy(u => u.Email == ownerDto.Email && u.Password == ownerDto.Password && u.IsVerified == true)
                .FirstOrDefault();
            if (result == null)
                return "Email or Password Is In Valid";
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
                    result.MemberStatusId = MemberStatusEnum.Available;
                    result.ImagePath = UploadImage(owner.ImageFile);
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
        public string UploadImage(IFormFile imageFile)
        {
            if (imageFile == null)
                return "DefaultPersonImage.png";
            else
            {
                var imageName = _commonService.UploadImage(imageFile, "Owners");
                return imageName.Result;
            }
        }
        public string AddPhoneNumber(PhoneModelDto owner)
        {
            if (!NumberIsUnique(owner.PhoneNumber))
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
        public bool NumberIsUnique(string phoneNumber)
        {
            Owner result = _ownerRepository.FindBy(u => u.PhoneNumber == phoneNumber).FirstOrDefault();
            if (result == null) return true; // mean this number not used
            return false;
        }

        public List<Owner> Get()
        {

         List<Owner> owners =  _ownerRepository.Get().ToList();
         
         return owners;

        }

        public Owner GetById(Guid id)
        {
         return   _ownerRepository.FindBy(o => o.Id == id).FirstOrDefault();
        }

        public void Save(Owner owner)
        {
            _ownerRepository.Edit(owner);
        }

        public bool IfBlocked(Guid ownerId)
        {
         var result=   _ownerRepository.FindBy(o => o.Id == ownerId).FirstOrDefault();
         if (result.MemberStatusId == MemberStatusEnum.Blocked) return true;
         return false;
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
