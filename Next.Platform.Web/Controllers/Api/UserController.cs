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
        public UserController(IPlayGroundBookingService bookingService)
        {
            this._bookingService = bookingService;
        }

        [HttpPost]
        [Route("Reserve")]
        public ActionResult Reserve([FromForm] ReserveDto reserveDto)
        {
            var result = _bookingService.Reserve(reserveDto);
            return Ok(result);
        }
    }
}
