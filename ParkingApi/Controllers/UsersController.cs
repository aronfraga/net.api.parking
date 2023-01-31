using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Models;
using ParkingApi.Models.DTO.UserDTO;
using ParkingApi.Repository;
using ParkingApi.Repository.IRepository;

namespace ParkingApi.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase {

		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UsersController(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterUser([FromBody] User userCreateDTO) {
			try {
				var response = _unitOfWork.User.RegisterUser(_mapper.Map<User>(userCreateDTO));
				return StatusCode(201, new { request_status = "successful", response = response.Result });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}


	}
}
