using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Next.Platform.Application.Dtos
{
   public class PlayGroundCategoryDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid NeighborhoodId { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid OwnerId { get; set; }
    }
}
