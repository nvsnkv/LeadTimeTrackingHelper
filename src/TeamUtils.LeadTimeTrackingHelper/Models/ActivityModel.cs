using System.ComponentModel.DataAnnotations;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;

namespace TeamUtils.LeadTimeTrackingHelper.Models
{
    public class ActivityModel:Activity
    {
        [Required]
        public new string Key { get; set; }

        public bool IsNew { get; set; }
    }
}
