using System.Collections.Generic;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public class Activity:UniqueItem
    {         
        ICollection<Tag> Tags { get; set; }
    }
}
