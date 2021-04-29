using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Application.Dtos
{
   public class ReserveDto
    {
        public Guid UserId { get; set; }
        public Guid PlayGroundId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
