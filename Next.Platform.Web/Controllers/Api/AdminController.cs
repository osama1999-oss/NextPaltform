using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController( IAdminService adminService)
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
        [HttpGet]
        [Route("GetOwners")]
        public ActionResult GetOwnerInAdminViewModel()
        {
            List<OwnerInAdminViewModel> results = _adminService.GetOwners();
            return Ok(results);
        }
        [HttpPost]
        [Route("BlockOwner")]
        public ActionResult BlockOwner(Guid id)
        {
            string results = _adminService.BlockOwner(id);
            return Ok(results);
        }
        [HttpPost]
        [Route("UnBlockOwner")]
        public ActionResult UnBlockOwner(Guid id)
        {
            string results = _adminService.UnBlockOwner(id);
            return Ok(results);
        }
        [HttpGet]
        [Route("GetBlockedOwners")]
        public ActionResult GetBlockedOwners()
        {
            var results = _adminService.GetBlockedOwners();
            return Ok(results);
        }
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            var results = _adminService.GetUsers();
            return Ok(results);
        }

    }
}
