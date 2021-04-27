using System;
using System.Collections.Generic;
using System.Text;
using Next.Platform.Core.StatusEnum;

namespace Next.Platform.Application.ViewModel
{
  public  class OwnerInAdminViewModel
    {
        public Guid NeighborhoodId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
