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
using Next.Platform.Application.ViewModel;
using Next.Platform.Core.Model;
using Next.Platform.Core.StatusEnum;
using Next.Platform.Infrastructure.AppContext;
using Next.Platform.Infrastructure.IBaseRepository;

namespace Next.Platform.Application.Services
{
   public class UserService : IUserService
   {
       private readonly IRepository<User> _userRepository;
       private readonly IAuthenticateService _authenticateService;
       private readonly IMapper _mapper;
       private readonly IVerificationService _verificationService;
       private readonly ICommonService _commonService;
       private readonly NextPlatformDbContext _context;
       private readonly IPlayGroundBookingService _bookingService;
        public UserService(ICommonService commonService, IVerificationService verificationService,
            IRepository<User> useRepository, IMapper mapper, IAuthenticateService authenticateService
            , NextPlatformDbContext context, IPlayGroundBookingService bookingService)
        {
            this._userRepository = useRepository;
            this._mapper = mapper;
            this._authenticateService = authenticateService;
            this._verificationService = verificationService;
            this._commonService = commonService;
            this._context = context;
            this._bookingService = bookingService;
        }

        public List<PlayGroundReservationsViewModel> GetCurrentReservations(Guid UserId)
        {
            var result = _bookingService.GetCurrentReservations().Where(u => u.UserId == UserId).ToList();
            return result;
        }

        public List<PlayGroundReservationsViewModel> GetReservationsHistory(Guid UserId)
        {
            var result = _bookingService.GetReservationsHistory().Where(u => u.UserId == UserId).ToList();
            return result;
        }

        public string Login(UserAuthenticationDto userDto)
        {
             User result= _userRepository.FindBy(u => u.PhoneNumber == userDto.PhoneNumber && u.Password == userDto.Password && u.IsVerified == true)
                    .FirstOrDefault();
             //string token = null;   
             //if(result != null)
             //{
             //    var userDtoResult = _mapper.Map<UserAuthenticationDto>(result);
             //     token = _authenticateService.GenerateJSONWebToken(result.Name);
             //}
             if (result == null) return "unauthorized";

            return result.Id.ToString();
        }
        public string Register(MemberModelDto user)
        {
            try
            {
                // user => phone number 
                var result = _mapper.Map<User>(user);
                result.Id=Guid.NewGuid();
                result.ImagePath =UploadImage(user.ImageFile, "Users");
                _userRepository.Add(result);
                return result.Id.ToString();
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
        public  string UploadImage(IFormFile imageFile , string folderName)
        {
            if (imageFile == null)
                return "DefaultPersonImage.png";
            else
            {
                var imageName = _commonService.UploadImage(imageFile, "Users");
                return imageName.Result;
            }
        }
        public string AddPhoneNumber(PhoneModelDto user)
        {
            if (!NumberIsUnique(user.PhoneNumber))
                return "This Number Already In USe";

            User result = _userRepository.FindBy(u => u.Id == user.Id).FirstOrDefault();
            result.PhoneNumber = user.PhoneNumber;
            _userRepository.Edit(result);
            string phoneNumber = _verificationService.NumberToInternationalFormat(result.PhoneNumber);
            string status =  _verificationService.SendVerificationCode(phoneNumber);
            if (status == "pending")
                return result.Id.ToString();
            return "We have problem to send Verification Code";
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

        public List<UserInAdminViewModel> Get()
        {
            var result = from u in _context.Users
                         join l in _context.Neighborhoods on u.NeighborhoodId equals l.Id
                         select new UserInAdminViewModel()
                         {
                             Email = u.Email,
                             ImagePath = u.ImagePath,
                             Location = l.Name,
                             Name = u.Name,
                             PhoneNumber = u.PhoneNumber
                         };
            return result.ToList();
        }

    }
}
