﻿using Social.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Social.ViewModels;
namespace Social.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController() 
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.Category)
                .Where(e => e.DateTime > DateTime.Now);

            var viewModel = new EventsViewModel
            { UpcomingEvents = upcomingEvents,
                ShowActions = User.Identity.IsAuthenticated,
            Heading = "Upcoming Events"
            };

        return View("Events", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}