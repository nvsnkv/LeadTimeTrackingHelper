using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeamUtils.LeadTimeTrackingHelper.Models.Validation;

namespace TeamUtils.LeadTimeTrackingHelper.Models
{
    public class TrackChangeRequest
    {
        [Required]
        public string Activity { get; set; }

        [Required]
        public string From { get; set; }

        [Required, NotMatch("From")]
        public string To { get; set; }

        [Timestamp]
        public string Timestamp { get; set; }
    }
}
