using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOwnerService _ownerService;
        public RegistrationController(IUserService userService, IOwnerService ownerService)
        {
            this._userService = userService;
            this._ownerService = ownerService;
        }

        [HttpPost]
        [Route("UserRegistration")]
        public ActionResult UserRegister([FromForm] MemberModelDto user)
        {

            string result = _userService.Register(user);
            
            return Ok(new {result});
        }

        [HttpPost]
        [Route("SendUserVerificationCode")]
        public ActionResult SendUserVerificationCode([FromForm] PhoneModelDto user)
        {
            string result= _userService.AddPhoneNumber(user);
            if (string.IsNullOrEmpty(result))
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("CheckUserVerificationCode")]
        public ActionResult CheckUserVerificationCode([FromForm] VerificationCodeDto verificationCode)
        { 
            string status =  _userService.CheckVerificationCode(verificationCode);
             return Ok(status);
        }

        [HttpPost]
        [Route("OwnerRegistration")]
        public ActionResult OwnerRegister([FromForm] MemberModelDto owner)
        {

            string result = _ownerService.Register(owner);
                return Ok(new { result });

        }

        [HttpPost]
        [Route("SendOwnerVerificationCode")]
        public ActionResult SendOwnerVerificationCode([FromForm] PhoneModelDto owner)
        {
            string result = _ownerService.AddPhoneNumber(owner);
            if (string.IsNullOrEmpty(result))
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("CheckOwnerVerificationCode")]
        public ActionResult CheckOwnerVerificationCode([FromForm] VerificationCodeDto verificationCode)
        {
            string status = _ownerService.CheckVerificationCode(verificationCode);
            return Ok(status);
        }



    }
}
