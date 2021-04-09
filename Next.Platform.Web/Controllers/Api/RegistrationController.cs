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
        public ActionResult Register([FromForm] UserModelDto user)
        {

            Guid result = _userService.Register(user);
            
            return Ok(new {result});
        }

        [HttpPost]
        [Route("SendVerificationCode")]
        public ActionResult SendVerificationCode([FromForm] UserPhoneModelDto user)
        {
            string result= _userService.AddPhoneNumber(user);
            if (string.IsNullOrEmpty(result))
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        [Route("CheckVerificationCode")]
        public ActionResult CheckVerificationCode([FromForm] VerificationCodeDto verificationCode)
        { 
            string status =  _userService.CheckVerificationCode(verificationCode);
             return Ok(status);
        }

        [HttpPost]
        [Route("OwnerRegistration")]
        public ActionResult Register([FromForm] OwnerModelDto owner)
        {

            bool result = _ownerService.Register(owner);
            if (result)
                return Ok(new { result });
            return BadRequest();

        }




    }
}
