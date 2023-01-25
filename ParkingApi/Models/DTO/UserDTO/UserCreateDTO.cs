using ParkingApi.Utils;
using System.ComponentModel.DataAnnotations;

namespace ParkingApi.Models.DTO.UserDTO {
	public class UserCreateDTO {

		[Required(ErrorMessage = Messages.USER_NO_EMAIL )]
		public string Email { get; set; } 

		[Required(ErrorMessage = Messages.USER_NO_PASS)]
		public string Password { get; set; } 

		[Required(ErrorMessage = Messages.USER_NO_FIRNA)]
		public string FirstName { get; set; } 

		[Required(ErrorMessage = Messages.USER_NO_LASTNA)]
		public string LastName { get; set; }

	}
}
