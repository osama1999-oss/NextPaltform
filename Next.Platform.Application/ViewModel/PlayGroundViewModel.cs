using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
   public class PlayGroundViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<string> Image { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal PriceEvening { get; set; }
        public decimal PriceMorning { get; set; }
        public bool HasBall { get; set; }
        public bool HasWater { get; set; }
        public bool HasGarag { get; set; }
        public bool HasLoacker { get; set; }
        public bool HasShower { get; set; }
        public bool HasToilet { get; set; }
        public int Rating { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }  
        public List<int> ReservedHours { get; set; }

    }
}
