using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }
        [HttpPost]
        [Route("PlaygroundApproval")]
        public ActionResult PlaygroundApproval([FromForm] PlayGroundRequestDto playGroundRequestDto)
        {
           string result =   _adminService.PlaygroundApproval(playGroundRequestDto);
            return Ok(result);
        }   
    }
}
