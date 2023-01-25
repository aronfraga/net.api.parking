namespace ParkingApi.Models {    
    public class Reservation {

        public int Id { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public bool IsPaid { get; set; }

		public int SpotId { get; set; }
		public Spot Spot { get; set; } = new Spot();

        public int UserId { get; set; }
		public User User { get; set; } = new User();

	}
}
