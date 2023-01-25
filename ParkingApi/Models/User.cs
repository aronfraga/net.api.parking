namespace ParkingApi.Models {
    public class User {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Role { get; set; }
		public bool Active { get; set; } = true;

		public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }

    }
}
