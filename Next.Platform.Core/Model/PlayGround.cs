using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
  public  class PlayGround : BaseEntity
    {
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
        public int Rating { get; set; }
        public string Location { get; set; }
        public PlayGroundTypeEnum PlayGroundTypeId { get; set; }

        public Guid PlayGroundCategoryId { get; set; }
        public PlayGroundCategory PlayGroundCategory { get; set; }
        public List<PreferredPlayGround> PreferredPlayGrounds { get; set; }
        public List<PlayGroundBooking> PlayGroundBookings { get; set; }
        public List<Comment> Comments { get; set; }
        public List<PlayGroundImages> PlayGroundImages { get; set; }
        public PlayGroundStatusEnum PlayGroundStatusId { get; set; }


    }
}
