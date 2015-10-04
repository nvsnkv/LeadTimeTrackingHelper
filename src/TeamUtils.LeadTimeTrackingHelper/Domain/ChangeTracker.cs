using System;
using System.Collections.Generic;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;

namespace TeamUtils.LeadTimeTrackingHelper.Domain
{
    public class ChangeTracker
    {
        private readonly Repository _repository;

        public ChangeTracker(Repository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        public void Track(string activityKey, string fromKey, string toKey, DateTime timestamp)
        {
            var activity = _repository.GetActivity(activityKey);
            var from = _repository.GetState(fromKey);
            var to = _repository.GetState(toKey);

            var change = new Change
            {
                Activity = activity,
                From = from,
                To = to,
                Timestamp = timestamp
            };

            _repository.Add(change);
        }

        public IEnumerable<Change> GetRecentChanges()
        {
            return _repository.GetChanges(20);
        }
    }
}
