using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Next.Platform.Application.IServices;
using Next.Platform.Application.ViewModel;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IPlayGroundService _playGroundService;
        private readonly IAdminService _adminService;
        private readonly IPlayGroundBookingService _bookingService;

        public StatisticsController(IPlayGroundService playGroundService, IAdminService adminService, IPlayGroundBookingService bookingService)
        {
            this._playGroundService = playGroundService;
            this._adminService = adminService;
            this._bookingService = bookingService;

        }
        [HttpGet]
        [Route("DailyStatisticsOfReservations")]
        public ActionResult DailyStatisticsOfReservations()
        {
            var result = _bookingService.DailyStatisticsOfReservations();
            return Ok(result);
        }
        [HttpGet]
        [Route("PlayGroundStatusStatistics")]
        public ActionResult PlayGroundStatusStatistics()
        {

            var result = _playGroundService.PlayGroundStatusStatistics();
            return Ok(result);
        }

        [HttpGet]
        [Route("StatisticsOfReservations")]
        public ActionResult StatisticsOfReservations()
        {

         var result =  _bookingService.StatisticsOfReservations();
         List<StatisticReservationsViewModel> results = new List<StatisticReservationsViewModel>();
         for (int i = 0; i < 4; i++)
         {
             StatisticReservationsViewModel data = new StatisticReservationsViewModel();
               data.Name=  _playGroundService.GetById(result[i].Id).Name;
               data.Value = result[i].Value;
               results.Add(data);
         }
         return Ok(results);
        }
        [HttpGet]
        [Route("GetPlayGroundsCount")]
        public ActionResult GetPlayGroundsCount()
        {

            var result = _playGroundService.GetAllPlayPlayGroundCount();
            return Ok( result );
        }
        [HttpGet]
        [Route("GetPlayGroundApprovalCount")]
        public ActionResult GetPlayGroundApprovalCount()
        {

            var result = _playGroundService.GetPlayGroundApprovalViewModelCount();
            return Ok(result );
        }
        [HttpGet]
        [Route("GetUsersCount")]
        public ActionResult GetUsersCount()
        {

            var result = _adminService.GetUsersCount();
            return Ok( result );
        }
        [HttpGet]
        [Route("GetOwnersCount")]
        public ActionResult GetOwnersCount()
        {

            var result = _adminService.GetOwnersCount();
            return Ok( result );
        }
    }
}
