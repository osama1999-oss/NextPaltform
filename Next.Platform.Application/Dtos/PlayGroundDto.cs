using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Application.Dtos
{
  public class PlayGroundDto
    { 
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal PriceEvening { get; set; }
        public decimal PriceMorning { get; set; }
        public bool HasBall { get; set; }
        public bool HasWater { get; set; }
        public bool HasGarag { get; set; }
        public bool HasLoacker { get; set; }
        public bool HasShower { get; set; }
        public bool HasToilet { get; set; }
        public Guid PlayGroundCategoryId { get; set; }
        public PlayGroundTypeEnum PlayGroundTypeId { get; set; }
        public string Location { get; set; }
        public IFormFile[] ImageFile { get; set; }

    }
}
