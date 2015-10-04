using System;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public class Change
    {
        public Activity Activity { get; set; }
        public State From { get; set; }
        public State To { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
