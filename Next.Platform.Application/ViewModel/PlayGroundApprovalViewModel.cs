using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
  public class PlayGroundApprovalViewModel
    {
        public Guid PlayGroundId { get; set; }
        public string PlayGroundName { get; set; }
        public string OwnerName { get; set; }
        public string PlayGroundLocation { get; set; }
        public List<string> Images { get; set; }
        public decimal PriceEvening { get; set; }
        public decimal PriceMorning { get; set; }
        public string Email { get; set; }
    }
}
