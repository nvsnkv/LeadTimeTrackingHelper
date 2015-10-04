using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;
using TeamUtils.LeadTimeTrackingHelper.Models;

namespace TeamUtils.LeadTimeTrackingHelper.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly Repository _repository;

        public ActivitiesController(Repository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetActivities().Select(a => new ActivityModel { Key = a.Key }));
        }

        [HttpPost]
        public IActionResult Add(ActivityModel model)
        {
            if (ModelState.IsValid)
            {
                var activity = _repository.GetActivity(model.Key);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ActivityModel model)
        {
            _repository.Remove(_repository.GetActivity(model.Key));
            return RedirectToAction("Index");
        }
    }
}
