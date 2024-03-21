using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Egyptopia.Persistence.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TourGuide> TourGuids { get; set; }
        public DbSet<TourGuideService> TourGuideServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>()
                .HasOne(e => e.Governorate)
                .WithMany(e => e.Places)
                .HasForeignKey(e => e.GovernorateId);
                
            modelBuilder.Entity<Room>()
                .HasOne(e => e.Hotel)
                .WithMany(e => e.Rooms)
                .HasForeignKey(e => e.HotelId);

            modelBuilder.Entity<TourGuideService>()
                .HasKey(e => new
                {
                    e.TourGuideId,
                    e.PlaceId
                });
        }





    }
}
