using ParkingApi.Data;
using ParkingApi.Repository.IRepository;

namespace ParkingApi.Repository {
	public class UnitOfWork : IUnitOfWork {

		private readonly Context _dbcontext;

		public UnitOfWork(Context dbcontext, IConfiguration config) {
			_dbcontext = dbcontext;
			User = new UserRepository(dbcontext, config);
			Vehicle = new VehicleRepository(dbcontext);
		}

		public IUserRepository User { get; private set; }
		public IVehicleRepository Vehicle { get; private set; }

	}
}
