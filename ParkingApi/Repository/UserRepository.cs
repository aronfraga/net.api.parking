using Microsoft.EntityFrameworkCore;
using ParkingApi.Data;
using ParkingApi.Models;
using ParkingApi.Repository.IRepository;
using ParkingApi.Utils;
using XSystem.Security.Cryptography;

namespace ParkingApi.Repository {
	public class UserRepository : IUserRepository {

		private readonly Context _dbcontext;
		private string _secret;

		public UserRepository(Context dbcontext, IConfiguration config) {
			_dbcontext = dbcontext;
			_secret = config.GetValue<string>("ApiSettings:Secret");
		}

		public async Task<bool> ExistUser(string email) {
			bool valueEmail = await _dbcontext.Users.AnyAsync(data => data.Email.ToLower().Trim() == email.ToLower().Trim());
			return valueEmail;
		}

		public Task<User> LoginUser(User user) {
			throw new NotImplementedException();
		}

		public async Task<string> RegisterUser(User user) {

			new System.Net.Mail.MailAddress(user.Email);
			if (await ExistUser(user.Email)) throw new Exception(Messages.USER_EXIST);

			var PasswordEncrypted = EncryptMD5(user.Password);

			User newUser = new User() {
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Role = "User",
				Password = PasswordEncrypted,
			};

			await _dbcontext.Users.AddAsync(newUser);
			await _dbcontext.SaveChangesAsync();

			return Messages.CREATED;

		}

		public static string EncryptMD5(string value) {
			MD5CryptoServiceProvider X = new MD5CryptoServiceProvider();
			byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
			data = X.ComputeHash(data);
			string response = "";
			for (int i = 0; i < data.Length; i++) {
				response += data[i].ToString("x2").ToLower();
			}
			return response;
		}

	}
}
