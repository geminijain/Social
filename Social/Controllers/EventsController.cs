using Microsoft.AspNet.Identity;
using Social.Models;
using Social.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Social.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Attendances
                .Where( a => a.AttendeeId == userId)
                .Select(a => a.Event)
                   .Include(e => e.Organizer)
                .Include(e => e.Category)
                .ToList();

            var viewModel = new EventsViewModel()
            {
                UpcomingEvents = events,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Events I'm Attending"
            };

            return View("Events", viewModel);

        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }
            var event1 = new Event
            {
                OrganizerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Venue = viewModel.Venue
            };

            _context.Events.Add(event1);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}