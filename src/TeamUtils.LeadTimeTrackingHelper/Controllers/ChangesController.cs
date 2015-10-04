using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamUtils.LeadTimeTrackingHelper.Models;
using TeamUtils.LeadTimeTrackingHelper.Domain;
using System;


namespace TeamUtils.LeadTimeTrackingHelper.Controllers
{
    public class ChangesController : Controller
    {
        private readonly ChangeTracker _tracker;

        public ChangesController(ChangeTracker tracker)
        {
            if (tracker == null)
                throw new ArgumentNullException(nameof(tracker));

            _tracker = tracker;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var requests = _tracker.GetRecentChanges().Select(x => new TrackChangeRequest
            {
                Activity = x.Activity.Key,
                From = x.From.Key,
                To = x.To.Key,
                Timestamp = x.Timestamp.ToString()
            }).ToList();
            return View(requests);
        }

        [HttpPost]
        public IActionResult Track(TrackChangeRequest request)
        {
            if (ModelState.IsValid)
            {
                DateTime time;
                if (DateTime.TryParse(request.Timestamp, out time))
                {
                    _tracker.Track(request.Activity, request.From, request.To, time);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Timestamp", "Timestamp should represent valid date and time");
                }
            }

            return View(request);
        }
    }
}
