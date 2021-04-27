using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
   public class Owner :Member
    {
        public Guid NeighborhoodId { get; set; }

        public List<PlayGroundCategory> PlayGroundCategories { get; set; }
        public MemberStatusEnum MemberStatusId { get; set; }

    }
}
