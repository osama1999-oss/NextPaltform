using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Next.Platform.Application.Dtos
{
  public class OwnerModelDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
