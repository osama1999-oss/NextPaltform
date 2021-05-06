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
    public class UserController : ControllerBase
    {
        private readonly IPlayGroundBookingService _bookingService;
        private readonly IUserService _userService;
        public UserController(IPlayGroundBookingService bookingService, IUserService userService)
        {
            this._userService = userService;
            this._bookingService = bookingService;
        }

        [HttpPost]
        [Route("Reserve")]
        public ActionResult Reserve([FromForm] ReserveDto reserveDto)
        {
            var result = _bookingService.Reserve(reserveDto);
            return Ok(result);
        }


        [HttpPost]
        [Route("CancelReservation")]
        public ActionResult CancelReservation([FromForm] Guid reservationId)
        {
             _bookingService.CancelReservation(reservationId);
            return Ok("Done");
        }

        [HttpPost]
        [Route("AddPlayGroundToPreferred")]
        public ActionResult AddPlayGroundToPreferred([FromForm] PreferredDto preferredDto)
        {
              _userService.AddPlayGroundToPreferred(preferredDto);
            return Ok("Done");
        }

        [HttpPost]
        [Route("GetPreferredPlayGround")]
        public ActionResult GetPreferredPlayGround([FromForm] Guid userId)
        {
          var result=   _userService.GetPreferredPlayGrounds(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetCurrentReservations")]
        public ActionResult GetCurrentReservations([FromForm] Guid id)
        {
            var result = _userService.GetCurrentReservations(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetUser")]
        public ActionResult GetUser([FromForm] Guid userId)
        {
            var result = _userService.GetById(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetReservationsHistory")]
        public ActionResult GetReservationsHistory([FromForm] Guid Id)
        {
            var result = _userService.GetReservationsHistory(Id);
            return Ok(result);
        }
    }
}
