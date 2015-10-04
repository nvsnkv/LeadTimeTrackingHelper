using System;
using System.ComponentModel.DataAnnotations;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public class Change
    {
        [Key]
        public int Id { get; set; }

        public Activity Activity { get; set; }
        public State From { get; set; }
        public State To { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
