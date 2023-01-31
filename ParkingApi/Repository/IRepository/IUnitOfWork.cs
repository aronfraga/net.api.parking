namespace ParkingApi.Repository.IRepository {
	public interface IUnitOfWork {

		IUserRepository User { get; }
		IVehicleRepository Vehicle { get; }
		ISpotRepository Spot { get; }

	}
}
