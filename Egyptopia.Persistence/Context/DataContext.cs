using Egyptopia.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Egyptopia.Persistence.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<TourGuide> TourGuids { get; set; }
        public DbSet<TourGuideService> TourGuideServices { get; set; }
        public DbSet<HotelComment> HotelComments { get; set; }

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

            modelBuilder.Entity<Hotel>()
                .HasOne(e => e.Governorate)
                .WithMany(e => e.Hotels)
                .HasForeignKey(e => e.GovernorateId);

            modelBuilder.Entity<HotelComment>()
                .HasOne(e => e.Hotel)
                .WithMany(e => e.HotelComments)
                .HasForeignKey(e => e.HotelId);

            modelBuilder.Entity<HotelComment>()
                .HasOne(e => e.ApplicationUser)
                .WithMany(e => e.HotelComments)
                .HasForeignKey(e => e.ApplicationUserId);

            modelBuilder.Entity<TourGuideService>()
                .HasKey(e => new
                {
                    e.TourGuideId,
                    e.PlaceId
                });
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.TourGuide)
                .WithMany()
                .HasForeignKey(b => b.TourGuideId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId);
                
        }
    }
}