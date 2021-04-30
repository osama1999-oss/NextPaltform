using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class PlayGroundBooking
    {
        public Guid Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime DateOnly { get; set; }
        public PlayGroundBookingStatusEnum PlayGroundBookingStatusId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PlayGroundId { get; set; }
    }
}
