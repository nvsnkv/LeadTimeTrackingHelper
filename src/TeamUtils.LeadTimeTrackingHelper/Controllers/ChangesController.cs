using System.Linq;
using Microsoft.AspNet.Mvc;
using TeamUtils.LeadTimeTrackingHelper.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamUtils.LeadTimeTrackingHelper.Controllers
{
    public class ChangesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Enumerable.Empty<TrackChangeRequest>());
        }

        [HttpPost]
        public IActionResult Track(TrackChangeRequest request)
        {
            if (ModelState.IsValid)
            {
                //TODO: save
                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }
    }
}
