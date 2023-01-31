using ParkingApi.Models;

namespace ParkingApi.Repository.IRepository {
	public interface IVehicleRepository {

		Task<ICollection<Vehicle>> GetAllVehicles();
		Task<Vehicle> GetOneVehicle(int id);
		Task<bool> ExistVehicle(string plate);
		Task<string> CreateVehicle(Vehicle vehicle);
		Task<string> UpdateVehicle(Vehicle vehicle);
		Task<string> DeleteVehicle(int id);

	}
}
