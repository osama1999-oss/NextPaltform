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
        public ActionResult PlaygroundApproval( PlayGroundRequestDto playGroundRequestDto)
        {

           var result =   _adminService.PlaygroundApproval(playGroundRequestDto);
            return Ok(new {result});
        }
        [HttpGet]
        [Route("GetOwners")]
        public ActionResult GetOwnerInAdminViewModel()
        {
            var results = _adminService.GetOwners();
            return Ok(results);
        }

        [HttpGet]
        [Route("BlockOwner/{ownerId}")]
        public ActionResult BlockOwner(string ownerId)
        {
            var Id = new Guid(ownerId);
            string results = _adminService.BlockOwner(Id);
            return Ok(new {results});
        }
        [HttpGet]
        [Route("UserSearch/{userName}")]
        public ActionResult UserSearch(string userName)
        {
            var results = _adminService.UsersSearch(userName);
            return Ok( results );
        }
        [HttpGet]
        [Route("OwnerSearch/{ownerName}")]
        public ActionResult OwnerSearch(string ownerName)
        {
            var results = _adminService.OwnersSearch(ownerName);
            return Ok(results);
        }
        [HttpGet]
        [Route("BlockedOwnerSearch/{ownerName}")]
        public ActionResult BlockedOwnerSearch(string ownerName)
        {
            var results = _adminService.BlockedOwnersSearch(ownerName);
            return Ok(results);
        }

        [HttpGet]
        [Route("UnBlockOwner/{ownerId}")]
        public ActionResult UnBlockOwner(string ownerId)
        {
            var id = new Guid(ownerId);
            string results = _adminService.UnBlockOwner(id);
            return Ok(new { results });
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
