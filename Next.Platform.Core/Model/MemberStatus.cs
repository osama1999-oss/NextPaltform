using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
    public class MemberStatus
    {
        public MemberStatusEnum Id { get; set; }
        public string Status { get; set; }
      //  public List<User> Users { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
