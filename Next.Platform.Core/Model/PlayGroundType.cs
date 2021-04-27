using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Core.Model
{
  public  class PlayGroundType
    {
        public PlayGroundTypeEnum Id { get; set; }
        public string Type { get; set; }
        public List<PlayGround> PlayGrounds { get; set; }
    }
}
