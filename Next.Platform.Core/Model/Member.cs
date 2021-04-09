using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Core.Model
{
   public class Member :BaseEntity
    {
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string Password{ get; set; }
        public string ImagePath{ get; set; }
        public bool IsVerified { get; set; }  
    }
}
