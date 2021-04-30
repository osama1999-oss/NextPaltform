using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.ViewModel
{
    public class PlayGroundReservationsViewModel
    {
        public Guid Id { get; set; }
        public Guid PlayGroundId { get; set; }
        public Guid UserId { get; set; }
        public string PlayGroundName { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
