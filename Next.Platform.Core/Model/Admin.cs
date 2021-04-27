using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
   public class Admin:BaseEntity
    {
        public Guid NeighborhoodId { get; set; }

        public string Password { get; set; }
    }
}
