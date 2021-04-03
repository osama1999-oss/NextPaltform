using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Core.Model;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController( IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("UserAuthentication")]
        public ActionResult Login( [FromForm] UserAuthenticationDto userAuthenticationDto)
        {
             
             var  result =_userService.Login(userAuthenticationDto);
             if (result == null)
             {
                 return BadRequest("Admin Not Found");
             }
             return Ok(result);
        }

    }
}
