using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Next.Platform.Application.IServices;

namespace Next.Platform.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            this._commonService = commonService;
        }
        [HttpGet]
        [Route("GetsNeighborhoods")]
        public ActionResult GetsNeighborhoods()
        {
            var results = _commonService.GetNeighborhoods();
            return Ok(results);
        }
    }
}
