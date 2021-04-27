using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Next.Platform.Application.Dtos
{
   public class MemberModelDto
    {
        public string Name { get; set; }
        public Guid NeighborhoodId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
