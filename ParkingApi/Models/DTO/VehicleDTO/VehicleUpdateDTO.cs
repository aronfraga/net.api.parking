using ParkingApi.Utils;
using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Models.DTO.VehicleDTO {
	public class VehicleUpdateDTO {

		[Required(ErrorMessage = Messages.VEHI_NO_ID)]
		public int Id { get; set; }

		[Required(ErrorMessage = Messages.VEHI_NO_PLATE)]
		public string Plate { get; set; } = string.Empty;

		[Required(ErrorMessage = Messages.USER_NO_EMAIL)]
		public int UserId { get; set; }

	}
}
