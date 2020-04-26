using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }

        public string Venue { get; set; }
        public string Organizer { get; set; }
        public string PictureUrl { get; set; }
        public int EventCategoryId { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationId { get; set; }
        public string EventCategory { get; set; }
        public string EventType { get; set; }
        public string EventLocation { get; set; }
    }
}
