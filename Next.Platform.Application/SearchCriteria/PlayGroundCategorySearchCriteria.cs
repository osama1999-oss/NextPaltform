using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.SearchCriteria
{
   public class PlayGroundCategorySearchCriteria
    {
        public Guid NeighborhoodId { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
    }
}
