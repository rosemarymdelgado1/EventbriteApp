using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCatalogApi.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Organizer { get; set; }
        public string PictureUrl { get; set; }
        public int EventCategoryId { get; set; }
        public int EventTypeId { get; set; }
        public int EventLocationId { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual EventLocation EventLocation { get; set; }
    }
}
