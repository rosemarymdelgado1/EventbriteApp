using Microsoft.EntityFrameworkCore;
using ServiceCatalogApi.Domain;
using System.Collections.Generic;
using System.Linq;


namespace ServiceCatalogApi.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EventCategory> eventcategory { get; set; }
        public DbSet<EventItem> eventitem { get; set; }
        public DbSet<EventLocation> eventlocation { get; set; }
        public DbSet<EventType> eventtype { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("eventcategory");
                e.Property(c => c.Id).IsRequired().UseHiLo("eventcategoryhilo");
                e.Property(c => c.Category).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("eventtype");
                e.Property(c => c.Id).IsRequired().UseHiLo("eventcategoryhilo");
                e.Property(c => c.Type).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("eventlocation");
                e.Property(l => l.Id).IsRequired().UseHiLo("eventlocationhilo");
                e.Property(l => l.City).IsRequired().HasMaxLength(100);
                e.Property(l => l.State).IsRequired().HasMaxLength(100);

            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.ToTable("eventItem");
                e.Property(i => i.Id).IsRequired().UseHiLo("eventcategoryhilo");
                e.Property(i => i.Title).IsRequired().HasMaxLength(100);
                e.Property(i => i.Venue).IsRequired().HasMaxLength(100);
                e.Property(i => i.Organizer).IsRequired().HasMaxLength(100);
                e.Property(i => i.Price).IsRequired();
                e.Property(i => i.Description).IsRequired().HasMaxLength(100);
                e.Property(i => i.EventDateTime).IsRequired();
                e.HasOne(i => i.EventCategory).WithMany().HasForeignKey(i => i.EventCategoryId);
                e.HasOne(i => i.EventLocation).WithMany().HasForeignKey(i => i.EventLocationId);
                e.HasOne(i => i.EventType).WithMany().HasForeignKey(i => i.EventTypeId);

            });


        }




    }
}
