using Microsoft.EntityFrameworkCore;
using ServiceCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCatalogApi.Data
{
    public class CatalogContext:DbContext 
    {
        public CatalogContext(DbContextOptions options)
            : base(options) { }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventItem> EventItems { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
    }
}
