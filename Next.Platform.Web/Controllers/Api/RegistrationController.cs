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
        private readonly IWebHostEnvironment _hostEnvironment;
        public RegistrationController(IUserService userService, IWebHostEnvironment hostEnvironment)
        {
            this._userService = userService;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        [Route("UserRegistration")]
        public ActionResult Register([FromForm] UserModelDto user)
        {

            bool result = _userService.Register(user);
            if (result)
                return Ok(new {result});
            return BadRequest();

        }

     



    }
}
