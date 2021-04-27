using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
   public class Neighborhood
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Owner> Owners { get; set; }
        public List<User> Users { get; set; }
        public List<PlayGroundCategory> PlayGroundCategories { get; set; }
    }
}
