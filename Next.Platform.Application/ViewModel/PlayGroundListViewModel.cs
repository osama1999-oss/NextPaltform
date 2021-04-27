using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
   public class PlayGroundListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal PriceEvening { get; set; }
        public decimal PriceMorning { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

    }
}
