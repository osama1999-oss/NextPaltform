using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
  public  class User:Member
    {
        public Guid NeighborhoodId { get; set; }

        public List<PreferredPlayGround> PreferredPlayGrounds{ get; set; }
        public List<PlayGroundBooking> PlayGroundBookings{ get; set; }
        public List<Comment> Comments { get; set; }
        public List<Replay> Replays { get; set; }

        //public MemberStatusEnum MemberStatusId { get; set; }
    }
}
