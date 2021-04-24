using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.StatusEnum
{
  public  enum PlayGroundStatusEnum :int
    {
        Pending = 0,
        Closed = 1,
        Approved = 2,
        InMaintenance = 3,
        Canceled = 4
    }
}
