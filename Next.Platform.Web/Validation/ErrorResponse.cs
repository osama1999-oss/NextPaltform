using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Next.Platform.Web.Validation
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
