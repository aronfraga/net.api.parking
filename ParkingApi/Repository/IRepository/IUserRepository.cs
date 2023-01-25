using ParkingApi.Models;

namespace ParkingApi.Repository.IRepository {
	public interface IUserRepository {

		Task<User> LoginUser(User user);
		Task<string> RegisterUser(User user);
		Task<bool> ExistUser(string email);

	}
}
