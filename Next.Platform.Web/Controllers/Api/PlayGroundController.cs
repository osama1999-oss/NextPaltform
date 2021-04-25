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
    public class PlayGroundController : ControllerBase
    {
        private readonly IPlayGroundService _playGroundService;
        public PlayGroundController(IPlayGroundService playGroundService)
        {
            this._playGroundService = playGroundService;
        }

        [HttpPost]
        [Route("CreatePlayGround")]
        public ActionResult CreatePlayGround([FromForm] PlayGroundDto playGround)
        {

            Guid result = _playGroundService.CreatePlayGround(playGround);

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetPlayGroundApprovalViewModel")]
        public ActionResult GetPlayGroundApprovalViewModel()
        {
            var result = _playGroundService.GetPlayGroundApprovalViewModel();

            return Ok(new { result });
        }
    }
}
