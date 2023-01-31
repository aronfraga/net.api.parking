namespace ParkingApi.Models {  
    public class Spot {
        
        public int Id { get; set; }
        public bool Status { get; set; } = true;

		public Reservation? Reservation { get; set; }

	}
}
