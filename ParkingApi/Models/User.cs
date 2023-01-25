using System.Text.Json.Serialization;

namespace ParkingApi.Models {
    public class User {

        public int Id { get; set; }
        public string Email { get; set; }
		
		[JsonIgnore]
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		
		[JsonIgnore]
		public string Role { get; set; }
        
		[JsonIgnore]
		public bool Active { get; set; }

		[JsonIgnore]
		public virtual ICollection<Vehicle> Vehicle { get; set; }

		[JsonIgnore]
		public virtual ICollection<Reservation> Reservation { get; set; }

    }
}
