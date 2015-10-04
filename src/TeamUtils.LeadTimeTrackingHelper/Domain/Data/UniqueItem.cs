using System.ComponentModel.DataAnnotations;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public abstract class UniqueItem
    {
        [Key]
        public string Key { get; set; }
    }
}
