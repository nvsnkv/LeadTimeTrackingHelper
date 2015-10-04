using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;

namespace TeamUtils.LeadTimeTrackingHelper.Domain.Data
{
    public class Repository
    {
        public class Context : DbContext
        {
            public DbSet<Activity> Activities { get; set; }
            public DbSet<State> States { get; set; }
            public DbSet<Change> Changes { get; set; }
        }

        private readonly Context _context;

        public Repository(Context context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<Activity> GetActivities()
        {
            return _context.Activities;
        }

        public Activity GetActivity(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key should not be empty!", nameof(key));

            var result = _context.Activities.FirstOrDefault(a => a.Key == key);
            if (result == null)
            {
                result = new Activity { Key = key };
                _context.Activities.Add(result);
                _context.SaveChanges();
            }

            return result;

        }

        public void Remove(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            var removingChanges = _context.Changes.Where(c => c.Activity.Key == activity.Key).ToList();

            foreach(var change in removingChanges)
            {
                _context.Changes.Remove(change);
            }

            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }

        public State GetState(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key should not be empty!", nameof(key));

            var result = _context.States.FirstOrDefault(a => a.Key == key);
            if (result == null)
            {
                result = new State { Key = key };
                _context.States.Add(result);
                _context.SaveChanges();
            }

            return result;

        }

        public IEnumerable<Change> GetChanges(int count)
        {
            return _context.Changes.Include(q => q.Activity).Include(q => q.From).Include(q => q.To).OrderByDescending(c => c.Timestamp).Take(count);
        }

        public void Add(Change change)
        {
            _context.Changes.Add(change);
            _context.SaveChanges();
        }
    }
}
