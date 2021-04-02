using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
  public  class User:Member
    {
        public List<PreferredPlayGround> PreferredPlayGrounds{ get; set; }
        public List<PlayGroundBooking> PlayGroundBookings{ get; set; }
        public List<Comment> Comments { get; set; }
        public List<Replay> Replays { get; set; }

    }
}
