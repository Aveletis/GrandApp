using GrandApp.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Models
{
    public class AppCtx : IdentityDbContext<User>
    {
        public AppCtx(DbContextOptions<AppCtx> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomPrice> RoomPrices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        /*public DbSet<User> User { get; set; }
       *//* public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }*//*

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            *//*modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Person");*//*
        }*/
    }
}
