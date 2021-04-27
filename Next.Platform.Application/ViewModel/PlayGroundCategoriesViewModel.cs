using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
   public class PlayGroundCategoriesViewModel
    {
        public Guid NeighborhoodId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public Guid Id { get; set; }

    }
}
