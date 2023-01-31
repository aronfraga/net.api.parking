using ParkingApi.Models;

namespace ParkingApi.Repository.IRepository {
	public interface ISpotRepository {

		Task<ICollection<Spot>> GetAllSpot();
		Task<Spot> GetOneSpot(int id);
		Task<bool> IsAvailable(int id);
		Task<string> SetSize(int size);

	}
}
