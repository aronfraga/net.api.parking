using AutoMapper;
using ParkingApi.Models;
using ParkingApi.Models.DTO.UserDTO;
using ParkingApi.Models.DTO.VehicleDTO;

namespace ParkingApi.Mapper {
	public class Mapper : Profile {

		public Mapper() {
			CreateMap<User, UserCreateDTO>().ReverseMap();

			CreateMap<Vehicle, VehicleCreateDTO>().ReverseMap();
			CreateMap<Vehicle, VehicleUpdateDTO>().ReverseMap();
			CreateMap<Vehicle, VehicleReturnDTO>().ReverseMap();

		}

	}
}
