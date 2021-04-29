using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class PlayGroundBooking
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public PlayGroundBookingStatusEnum PlayGroundBookingStatusId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PlayGroundId { get; set; }
    }
}
