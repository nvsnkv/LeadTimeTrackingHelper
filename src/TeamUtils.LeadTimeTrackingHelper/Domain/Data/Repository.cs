using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public class Repository
    {
        public class Context:DbContext
        {
            public DbSet<Activity> Activities { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<State> States { get; set; }
            public DbSet<Change> Changes { get; set; }
        }
    }
}
