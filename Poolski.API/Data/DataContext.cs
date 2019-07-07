using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Location> Locations {get; set;}
        public DbSet<LocationType> LocationTypes { get; set; }

        public DbSet<Trip> Trips { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<UserTrip>()
           .HasKey(bc => new{bc.TripId, bc.UserId});
           
           modelBuilder.Entity<UserTrip>()
           .HasOne(ut => ut.Trip)
           .WithMany(u => u.UserTrips)
           .HasForeignKey(ut => ut.TripId);
           modelBuilder.Entity<UserTrip>()
           .HasOne(ut => ut.User)
           .WithMany(t => t.UserTrips)
           .HasForeignKey(ut => ut.UserId);

        }
    }
}