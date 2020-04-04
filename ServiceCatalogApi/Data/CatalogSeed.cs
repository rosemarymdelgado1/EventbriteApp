using ServiceCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ServiceCatalogApi.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.eventcategory.Any())
            {
                context.eventcategory.AddRange(GetPreconfiguredeventcategory());

                context.SaveChanges();
            }

            if (!context.eventlocation.Any())
            {
                context.eventlocation.AddRange(GetPreconfiguredeventlocation());

                context.SaveChanges();
            }

            if (!context.eventtype.Any())
            {
                context.eventtype.AddRange(GetPreconfiguredeventtype());

                context.SaveChanges();
            }

            if (!context.eventitem.Any())
            {
                context.eventitem.AddRange(GetPreconfiguredeventitem());

                context.SaveChanges();
            }




        }



        private static IEnumerable<EventItem> GetPreconfiguredeventitem()
        {
            return new List<EventItem>()
           {
             new EventItem {EventCategoryId=1, EventTypeId=71, EventLocationId=1, Title = "Cravings on Wheels", Description = "Food Truck Festival" , Price = 5, Venue = "Seattle Centre",  Organizer = "Mobile Restaurant Council", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1"},
             new EventItem {EventCategoryId=2, EventTypeId=72, EventLocationId=2, Title = "Closing the Tech Gap", Description = "Job Fair", Price = 0, Venue = "Meydenbower Center", Organizer ="Women in Technology", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2"},
             new EventItem {EventCategoryId=8, EventTypeId=73, EventLocationId=3, Title = "Pixar Under the Stars", Description = "Outdoor Movies" , Price = 0, Venue = "Kirkland Marina", Organizer ="City of Kirkland", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3"},
             new EventItem {EventCategoryId=3, EventTypeId=74, EventLocationId=7, Title = "Distant Teaching Conference", Description = "Web-Based Teaching & Learning", Price = 40, Venue = "Bothell City Hall",  Organizer = "Northshore School District", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4"},
             new EventItem {EventCategoryId=4, EventTypeId=75, EventLocationId=7, Title = "Super Summer 5K", Description = "5K Run", Price = 25,  Venue = "Bothell City Hall", Organizer = "Keep Moving", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
             new EventItem {EventCategoryId=5, EventTypeId=76, EventLocationId=1, Title = "Sounds of the Andes", Description = "Peruvian Music Concert" , Price = 30, Venue = "Gasworks Park", Organizer = "Hola! Productions", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6"},
             new EventItem {EventCategoryId=6, EventTypeId=77, EventLocationId=6, Title = "Its Not Easy Being Green", Description = "Plant Based Nutrition Seminar", Price = 25, Venue = "Park", Organizer = "Organic Farmers of King County", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
             new EventItem {EventCategoryId=7, EventTypeId=75, EventLocationId=1, Title = "To Infinity and Beyond", Description = "Rocket Competition", Price = 50, Venue = "Warren G. Magnuson Park", Organizer = "Amateaur Rocket Club", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
             new EventItem {EventCategoryId=1, EventTypeId=71, EventLocationId=8, Title = "Eastside Beer Fest", Description = "Beer festival", Price = 30, Venue = "Marymoore Park", Organizer ="Brewers Association", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"},

             /*new EventItem {EventCategoryId=2, EventTypeId=4, EventLocationId=2, Title = "Networking for Healthcare", Description = "Networking principles for healthcare", Price = 45, Venue = "UW Bothell Auditorium", Organizer = "Healthcare Association", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10"},
             new EventItem {EventCategoryId=1, EventTypeId=8, EventLocationId=1, Title = "Pickling 101", Description = "Learn to pickle vegetables" , Price = 25, Venue = "Public Kitchen", Organizer = "Full Pantry", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11"},
             new EventItem {EventCategoryId=6, EventTypeId=8, EventLocationId=4, Title = "80's Roller Fest", Description = "RollerSkate to 80's music" , Price = 15, Venue = "Tacoma Roller Skating" , Organizer = "Roller Skate Inc.", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
             new EventItem {EventCategoryId=4, EventTypeId=8, EventLocationId=3, Title = "Happy Hour Zumba", Description = "Zumba class followed by a yummy cocktail" , Price = 20, Venue = "Juanita Community Center", Organizer ="Youth Orchestra Foundation", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13"},
             new EventItem {EventCategoryId=5, EventTypeId=6, EventLocationId=1, Title = "A Night with the Philarmonic", Description = "Youth Orchestra" , Price = 35, Venue = "Benaroya Hall" , Organizer = "Zumba Zone", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
             new EventItem {EventCategoryId=7, EventTypeId=8, EventLocationId=3, Title = "Relax Your Mind", Description = "Meditation" , Price =0, Venue = "Flow Yoga Studio", Organizer ="Youth Orchestra Foundation", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15"},
           */
        };

        }

        private static IEnumerable<EventLocation> GetPreconfiguredeventlocation()
        {
            return new List<EventLocation>()
        {
            new EventLocation {City = "Seattle", State= "Washington"},
            new EventLocation {City= "Bellevue", State="Washington"},
            new EventLocation {City = "Kirkland", State="Washington"},
            new EventLocation {City = "Tacoma", State=" Washington"},
            new EventLocation {City = "Snoqualmie",State=" Washington"},
            new EventLocation {City = "Woodinville", State=" Washington"},
            new EventLocation {City = "Bothell", State= " Washington"},
            new EventLocation {City= "Redmond", State= "Washington"}
        };

        }

        private static IEnumerable<EventType> GetPreconfiguredeventtype()
        {
            return new List<EventType>()
        {
            new EventType {Type = "Festival"},
            new EventType {Type = "Expo"},
            new EventType {Type = "Screening"},
            new EventType {Type = "Seminar"},
            new EventType {Type = "Competition"},
            new EventType {Type = "Concert"},
            new EventType {Type = "Convention"},
            new EventType {Type = "Other"}
        };
        }

        private static IEnumerable<EventCategory> GetPreconfiguredeventcategory()
        {
            return new List<EventCategory>()
        {
            new EventCategory {Category = "Food & Drink"},
            new EventCategory {Category = "Business & Professional"},
            new EventCategory {Category = "Education"},
            new EventCategory {Category = "Sports"},
            new EventCategory {Category = "Music"},
            new EventCategory {Category = "Healthness & Wellness"},
            new EventCategory {Category = "Science & Technology"},
            new EventCategory {Category = "Other"},
        };
        }
    }
}


        /*
        private static IEnumerable<EventItem> GetPreConfiguredItems()
        {
            return new List<EventItem>()
            {
                new EventItem {EventCategoryId=1, EventTypeId=1, EventLocationId=1, Title = "Cravings on Wheels", Description = "Food Truck Festival" , Price = 5, Venue = "Seattle Centre",  Organizer = "Mobile Restaurant Council", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1"},
                new EventItem {EventCategoryId=2, EventTypeId=2, EventLocationId=2, Title = "Closing the Tech Gap", Description = "Job Fair", Price = 0, Venue = "Meydenbower Center", Organizer ="Women in Technology", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2"},
                new EventItem {EventCategoryId=8, EventTypeId=3, EventLocationId=3, Title = "Pixar Under the Stars", Description = "Outdoor Movies" , Price = 0, Venue = "Kirkland Marina", Organizer ="City of Kirkland", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3"},
                new EventItem {EventCategoryId=3, EventTypeId=4, EventLocationId=7, Title = "Distant Teaching Conference", Description = "Web-Based Teaching & Learning", Price = 40, Venue = "Bothell City Hall",  Organizer = "Northshore School District", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4"},
                new EventItem {EventCategoryId=4, EventTypeId=5, EventLocationId=7, Title = "Super Summer 5K", Description = "5K Run", Price = 25,  Venue = "Bothell City Hall", Organizer = "Keep Moving", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
                new EventItem {EventCategoryId=5, EventTypeId=6, EventLocationId=1, Title = "Sounds of the Andes", Description = "Peruvian Music Concert" , Price = 30, Venue = "Gasworks Park", Organizer = "Hola! Productions", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventItem {EventCategoryId=6, EventTypeId=7, EventLocationId=6, Title = "Its Not Easy Being Green", Description = "Plant Based Nutrition Seminar", Price = 25, Venue = "Park", Organizer = "Organic Farmers of King County", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventItem {EventCategoryId=7, EventTypeId=5, EventLocationId=1, Title = "To Infinity and Beyond", Description = "Rocket Competition", Price = 50, Venue = "Warren G. Magnuson Park", Organizer = "Amateaur Rocket Club", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new EventItem {EventCategoryId=1, EventTypeId=1, EventLocationId=8, Title = "Eastside Beer Fest", Description = "Beer festival", Price = 30, Venue = "Marymoore Park", Organizer ="Brewers Association", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventItem {EventCategoryId=2, EventTypeId=4, EventLocationId=2, Title = "Networking for Healthcare", Description = "Networking principles for healthcare", Price = 45, Venue = "UW Bothell Auditorium", Organizer = "Healthcare Association", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventItem {EventCategoryId=1, EventTypeId=8, EventLocationId=1, Title = "Pickling 101", Description = "Learn to pickle vegetables" , Price = 25, Venue = "Public Kitchen", Organizer = "Full Pantry", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11"},
                new EventItem {EventCategoryId=6, EventTypeId=8, EventLocationId=4, Title = "80's Roller Fest", Description = "RollerSkate to 80's music" , Price = 15, Venue = "Tacoma Roller Skating" , Organizer = "Roller Skate Inc.", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventItem {EventCategoryId=4, EventTypeId=8, EventLocationId=3, Title = "Happy Hour Zumba", Description = "Zumba class followed by a yummy cocktail" , Price = 20, Venue = "Juanita Community Center", Organizer ="Youth Orchestra Foundation", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13"},
                new EventItem {EventCategoryId=5, EventTypeId=6, EventLocationId=1, Title = "A Night with the Philarmonic", Description = "Youth Orchestra" , Price = 35, Venue = "Benaroya Hall" , Organizer = "Zumba Zone", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventItem {EventCategoryId=7, EventTypeId=8, EventLocationId=3, Title = "Relax Your Mind", Description = "Meditation" , Price =0, Venue = "Flow Yoga Studio", Organizer ="Youth Orchestra Foundation", PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15"},
            };
        }
        private static IEnumerable<EventCategory> GetPreConfiguredCatalogItems()
        {
            return new List<EventCategory>()
            {
                new EventCategory {Category = "Food & Drink"},
                new EventCategory {Category = "Business & Professional"},
                new EventCategory {Category = "Education"},
                new EventCategory {Category = "Sports"},
                new EventCategory {Category = "Music"},
                new EventCategory {Category = "Healthness & Wellness"},
                new EventCategory {Category = "Science & Technology"},
                new EventCategory {Category = "Other"},
            };
        }

        private static IEnumerable<EventType> GetPreConfiguredCatalogItems()
        {
            return new List<EventType>()
            {
                new EventType {Type = "Festival"},
                new EventType {Type = "Expo"},
                new EventType {Type = "Screening"},
                new EventType {Type = "Seminar"},
                new EventType {Type = "Competition"},
                new EventType {Type = "Concert"},
                new EventType {Type = "Convention"},
                new EventType {Type = "Other"}
            };
        }

        private static IEnumerable<EventLocation> GePreConfiguredCatalogItems()
        {
            return new List<EventLocation>()
            {
                new EventLocation {Location = "Seattle, Washington"}, 
                new EventLocation {Location = "Bellevue, Washington"},
                new EventLocation {Location = "Kirkland, Washington"},
                new EventLocation {Location = "Tacoma, Washington"},
                new EventLocation {Location = "Snoqualmie, Washington"}, 
                new EventLocation {Location = "Woodinville, Washington"},
                new EventLocation {Location = "Bothell, Washington"},
                new EventLocation {Location = "Redmond, Washington"}
            };
        }
        */
    
