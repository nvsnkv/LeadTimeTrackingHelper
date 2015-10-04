using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamUtils.LeadTimeTrackingHelper.Models
{
    public class TrackChangeRequest
    {
        public string Activity { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Timestamp { get; set; }
    }
}
