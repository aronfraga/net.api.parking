using Microsoft.EntityFrameworkCore;
using ParkingApi.Models;
using System.Diagnostics;

namespace ParkingApi.Data {
	public class Context : DbContext {

		public Context(DbContextOptions<Context> options) : base(options) {
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Spot> Spots { get; set; }
		public DbSet<Reservation> Reservations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			modelBuilder.Entity<Vehicle>().HasOne<User>(data => data.User)
										  .WithMany(data => data.Vehicle)
										  .HasForeignKey(data => data.UserId);

			modelBuilder.Entity<Reservation>().HasOne<User>(data => data.User)
											  .WithMany(data => data.Reservation)
											  .HasForeignKey(data => data.UserId);

			modelBuilder.Entity<Reservation>().HasOne<Spot>(data => data.Spot)
											  .WithOne(data => data.Reservation);

		}

	}
}
