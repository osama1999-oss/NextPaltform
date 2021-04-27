using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
   public class PreferredPlayGround
    {
        public Guid UserId{ get; set; }
        public User User{ get; set; }
        
        public Guid PlayGroundId{ get; set; }
    }
}
