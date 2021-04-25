using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class Owner :Member
    {
        public List<PlayGround> PlayGrounds { get; set; }
        public MemberStatusEnum MemberStatusId { get; set; }

    }
}
