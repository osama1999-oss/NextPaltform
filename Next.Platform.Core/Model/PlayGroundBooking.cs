using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class PlayGroundBooking
    {
        public string Form { get; set; }
        public string To { get; set; }
        public DateTime BookingIn { get; set; }
        public PlayGroundBookingStatusEnum PlayGroundBookingStatusId { get; set; }

        public Guid UserId { get; set; }
        public Guid PlayGroundId { get; set; }
    }
}
