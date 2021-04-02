using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class PlayGroundStatus
    {
        public PlayGroundStatusEnum Id { get; set; }
        public string Status { get; set; }
        public List<PlayGround> PlayGrounds { get; set; }

    }
}
