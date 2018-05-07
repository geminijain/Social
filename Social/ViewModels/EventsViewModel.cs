using Social.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}