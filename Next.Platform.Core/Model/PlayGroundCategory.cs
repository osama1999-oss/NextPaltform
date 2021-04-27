using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
  public  class PlayGroundCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid NeighborhoodId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<PlayGround> playGrounds { get; set; }

    }
}
