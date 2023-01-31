using Microsoft.EntityFrameworkCore;
using ParkingApi.Data;
using ParkingApi.Models;
using ParkingApi.Repository.IRepository;
using ParkingApi.Utils;

namespace ParkingApi.Repository {
	public class SpotRepository : ISpotRepository {

		private readonly Context _dbcontext;

		public SpotRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<ICollection<Spot>> GetAllSpot() {
			return await _dbcontext.Spots.ToListAsync();
		}

		public async Task<Spot> GetOneSpot(int id) {
			var response = await _dbcontext.Spots.FirstOrDefaultAsync(data => data.Id == id);
			if (response == null) throw new Exception(Messages.VEHI_NO_EXIST);
			return response;
		}

		public async Task<bool> IsAvailable(int id) {
			bool value = await _dbcontext.Spots.AnyAsync(data => data.Status == true);
			return value;
		}

		public async Task<string> SetSize(int size) {
			//drop table if all status are true and then set new size review it

			for (int i = 0; i < size; i++) {
				Spot spot = new Spot();
				await _dbcontext.Spots.AddAsync(spot);
				await _dbcontext.SaveChangesAsync();
			}

			return Messages.CREATED;
		}

	}
}
