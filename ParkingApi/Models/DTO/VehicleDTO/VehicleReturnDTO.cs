namespace ParkingApi.Models.DTO.VehicleDTO {
	public class VehicleReturnDTO {

		public int Id { get; set; }
		public string Plate { get; set; }

		public User User { get; set; }

	}
}
