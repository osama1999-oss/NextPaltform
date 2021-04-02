using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class PlayGroundBookingStatus
    {
        public PlayGroundBookingStatusEnum Id { get; set; }
        public string Status { get; set; }
        public List<PlayGroundBooking> PlayGroundBookings { get; set; }
    }
}
