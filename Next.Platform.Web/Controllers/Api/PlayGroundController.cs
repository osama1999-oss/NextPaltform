using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Next.Platform.Application.Dtos;
using Next.Platform.Application.IServices;
using Next.Platform.Application.SearchCriteria;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayGroundController : ControllerBase
    {
        private readonly IPlayGroundService _playGroundService;
        private readonly IPlayGroundCategoryService _playGroundCategoryService;
        private readonly IPlayGroundBookingService _bookingService;
        public PlayGroundController(IPlayGroundCategoryService playGroundCategoryService, IPlayGroundBookingService bookingService,
            IPlayGroundService playGroundService)
        {
            this._playGroundService = playGroundService;
            this._playGroundCategoryService = playGroundCategoryService;
            this._bookingService = bookingService;
        }

        [HttpPost]
        [Route("CreatePlayGround")]
        public ActionResult CreatePlayGround([FromForm] PlayGroundDto playGround)
        {
            playGround.Location = _playGroundCategoryService.GetLocation(playGround.PlayGroundCategoryId);
            var result = _playGroundService.CreatePlayGround(playGround);

            return Ok(new { result });
        }
        [HttpPost]
        [Route("CreatePlayGroundCategory")]
        public ActionResult CreatePlayGroundCategory([FromForm] PlayGroundCategoryDto playGroundCategoryDto)
        {

            var result = _playGroundCategoryService.CreatePlayGroundCategory(playGroundCategoryDto);

            return Ok(new { result });
        }
        [HttpPost]
        [Route("GetReservedHours")]
        public ActionResult GetReservedHours([FromForm] ReservedHoursDto hoursDto)
        {

            var result = _bookingService.GetReservedHours(hoursDto.Id, hoursDto.Day);

            return Ok(new { result });
        }

        [HttpGet]
        [Route("GetCurrentReservations")]
        public ActionResult GetCurrentReservations()
        {

            var result = _bookingService.GetCurrentReservations();

            return Ok( result );
        }

        [HttpGet]
        [Route("GetReservationsHistory")]
        public ActionResult GetReservationsHistory()
        {

            var result = _bookingService.GetReservationsHistory();

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetPlayGroundApprovalViewModel")]
        public ActionResult GetPlayGroundApprovalViewModel()
        {
            var result = _playGroundService.GetPlayGroundApprovalViewModel();

            return Ok( result );
        }
        [HttpGet]
        [Route("GetPlayGroundTypes")]
        public ActionResult GetPlayGroundTypes()
        {
            var result = _playGroundService.GetTypes();

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetPlayGroundCategories")]
        public ActionResult GetPlayGroundCategories()
        {
            var result = _playGroundCategoryService.GetPlayGroundCategories();

            return Ok(new { result });
        }
        [HttpGet]
        [Route("GetAllPlayGrounds")]
        public ActionResult GetAllPlayGrounds()
        {
            var result = _playGroundService.GetAllPlayPlayGround();

                return Ok( result );
        }
        [HttpPost]
        [Route("Filter")]
        public ActionResult Filter([FromForm] PlayGroundCategorySearchCriteria categorySearchCriteria)
        {
            var result = _playGroundCategoryService.Filter(categorySearchCriteria);

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
