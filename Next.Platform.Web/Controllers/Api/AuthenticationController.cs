﻿using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticationController( IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("UserAuthenticate")]
        public ActionResult Login( [FromForm] UserAuthenticationDto userAuthenticationDto)
        {
            ActionResult response = Unauthorized();
             var  token =_userService.Login(userAuthenticationDto);
             if (token != null)
             {
                 response = Ok(new {token = token });
                 _httpContextAccessor.HttpContext.Response.Cookies.Append("token", token,new CookieOptions{HttpOnly = true});
             }
             return response;
        }
        
    }
}
