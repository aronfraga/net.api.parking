using Microsoft.EntityFrameworkCore;
using ParkingApi.Data;
using ParkingApi.Models;
using ParkingApi.Repository.IRepository;
using ParkingApi.Utils;

namespace ParkingApi.Repository {
	public class VehicleRepository : IVehicleRepository {

		private readonly Context _dbcontext;

		public VehicleRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<string> CreateVehicle(Vehicle vehicle) {
			if (await ExistVehicle(vehicle.Plate)) throw new Exception(Messages.VEHI_EXIST);
			await _dbcontext.Vehicles.AddAsync(vehicle);
			await _dbcontext.SaveChangesAsync();
			return Messages.CREATED;
		}

		public async Task<string> DeleteVehicle(int id) {
			var response = await GetOneVehicle(id);
			_dbcontext.Vehicles.Remove(response);
			return Messages.DELETED;
		}

		public async Task<bool> ExistVehicle(string plate) {
			bool value = await _dbcontext.Vehicles.AnyAsync(data => data.Plate.ToLower().Trim() == plate.ToLower().Trim());
			return value;
		}

		public async Task<ICollection<Vehicle>> GetAllVehicles() {
			return await _dbcontext.Vehicles.Include(data => data.User).ToListAsync();
		}

		public async Task<Vehicle> GetOneVehicle(int id) {
			var response = await _dbcontext.Vehicles.Include(data => data.User).FirstOrDefaultAsync(data => data.Id == id);
			if (response == null) throw new Exception(Messages.VEHI_NO_EXIST); 
			return response;
		}

		public async Task<string> UpdateVehicle(Vehicle vehicle) {
			var oldVehicle = await GetOneVehicle(vehicle.Id);
			if (oldVehicle == null) throw new Exception(Messages.VEHI_NO_EXIST);
			if (await ExistVehicle(vehicle.Plate)) throw new Exception(Messages.VEHI_EXIST);
			
			oldVehicle.Plate = vehicle.Plate;

			_dbcontext.Update(oldVehicle);
			await _dbcontext.SaveChangesAsync();
			return Messages.UPDATED;
		}

	}
}
