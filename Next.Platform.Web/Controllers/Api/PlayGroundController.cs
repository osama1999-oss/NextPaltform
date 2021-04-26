﻿using Microsoft.AspNetCore.Http;
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
        private readonly IPlayGroundCategoryService _playGroundCategoryService;
        public PlayGroundController(IPlayGroundCategoryService playGroundCategoryService, IPlayGroundService playGroundService)
        {
            this._playGroundService = playGroundService;
            this._playGroundCategoryService = playGroundCategoryService;
        }

        [HttpPost]
        [Route("CreatePlayGround")]
        public ActionResult CreatePlayGround([FromForm] PlayGroundDto playGround)
        {

            Guid result = _playGroundService.CreatePlayGround(playGround);

            return Ok(new { result });
        }
        [HttpPost]
        [Route("CreatePlayGroundCategory")]
        public ActionResult CreatePlayGroundCategory([FromForm] PlayGroundCategoryDto playGroundCategoryDto)
        {

            Guid result = _playGroundCategoryService.CreatePlayGroundCategory(playGroundCategoryDto);

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetPlayGroundApprovalViewModel")]
        public ActionResult GetPlayGroundApprovalViewModel()
        {
            var result = _playGroundService.GetPlayGroundApprovalViewModel();

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetPlayGroundCategories")]
        public ActionResult GetPlayGroundCategories()
        {
            var result = _playGroundCategoryService.GetPlayGroundCategories();

            return Ok(new { result });
        }
        [HttpPost]
        [Route("GetPlayGroundList")]
        public ActionResult GetPlayGroundList([FromForm] Guid playGroundCategoryId)
        {
            var result = _playGroundService.GetPlayGroundlist(playGroundCategoryId);

            return Ok(new { result });
        }
        [HttpPost]
        [Route("GetPlayGround")]
        public ActionResult GetPlayGround([FromForm] Guid playGroundId)
        {
            var result = _playGroundService.GetPlayGround(playGroundId);

            return Ok(new { result });
        }
    }
}
