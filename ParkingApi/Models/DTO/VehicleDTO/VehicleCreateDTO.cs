using ParkingApi.Utils;
using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Models.DTO.VehicleDTO {
	public class VehicleCreateDTO {

		[Required(ErrorMessage = Messages.VEHI_NO_PLATE)]
		public string Plate { get; set; } = string.Empty;

		[Required(ErrorMessage = Messages.USER_NO_ID)]
		public int UserId { get; set; }

	}
}
