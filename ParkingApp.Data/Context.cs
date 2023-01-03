using Microsoft.EntityFrameworkCore;
using ParkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Data {   
    public class Context : DbContext {

        public Context(DbContextOptions<Context> options) : base(options){
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
                .HasMany<Vehicle>(data => data.Vehicles)
                .WithMany(data => data.Users);
            modelBuilder.Entity<Reservation>()
                .HasMany<User>(data => data.Users)
                .WithMany(data => data.Reservations);
            base.OnModelCreating(modelBuilder);
        }

    }
}
