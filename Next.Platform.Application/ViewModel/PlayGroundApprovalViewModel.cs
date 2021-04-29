using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
  public class PlayGroundApprovalViewModel
    {
        public Guid PlayGroundId { get; set; }
        public Guid PlayGroundCategoryId { get; set; }
        public string PlayGroundName { get; set; }
        public string PlayGroundCategoryName { get; set; }
        public string Location { get; set; }
        public string OwnerName { get; set; }
        public Guid NeighborhoodId { get; set; }
        public List<string> Images { get; set; }
        public decimal PriceEvening { get; set; }
        public decimal PriceMorning { get; set; }
        public string Email { get; set; }
    }
}
