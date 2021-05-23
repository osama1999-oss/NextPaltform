using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
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
        private readonly IOwnerService _ownerService;
        private readonly IAdminService _adminService;
        public AuthenticationController(IAdminService adminService, IUserService userService,IOwnerService ownerService)
        {
            this._userService = userService;
            this._ownerService = ownerService;
            this._adminService = adminService;
        }

        [HttpPost]
        [Route("UserAuthenticate")]
        public ActionResult Login( [FromForm] UserAuthenticationDto userAuthenticationDto)
        {
           //  ActionResult response = Unauthorized();
             var  result =_userService.Login(userAuthenticationDto);
             //if (token != null)
             //{
             //    response = Ok(new {token = token });
             //    _httpContextAccessor.HttpContext.Response.Cookies.Append("token", token,new CookieOptions{HttpOnly = true});
             //}
             return Ok(result);
        }

        [HttpPost]
        [Route("OwnerAuthenticate")]
        public ActionResult Login([FromForm] OwnerAuthenticationDto ownerAuthenticationDto)
        {
            var owner = _ownerService.Login(ownerAuthenticationDto);
            
            return Ok(new {owner});
        }
                
        [HttpPost]
        [Route("AdminAuthenticate")]
        public ActionResult Login( AdminAuthenticationDto adminAuthenticationDto)
        {
            var admin = _adminService.Login(adminAuthenticationDto);

            return Ok(new { admin });
        }

    }
}
