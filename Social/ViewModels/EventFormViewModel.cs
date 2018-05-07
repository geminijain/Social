using Social.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Social.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime()
        {
            var dt = string.Format("{0} {1}", Date, Time);
            return DateTime.Parse(dt);
        }
    }
}