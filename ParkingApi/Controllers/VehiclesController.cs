using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Models;
using ParkingApi.Models.DTO.VehicleDTO;
using ParkingApi.Repository.IRepository;

namespace ParkingApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class VehiclesController : ControllerBase {

		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllVehicule() {
			try {
				var response = await _unitOfWork.Vehicle.GetAllVehicles();
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneVehicule(int id) {
			try {
				var response = _mapper.Map<VehicleReturnDTO>(await _unitOfWork.Vehicle.GetOneVehicle(id));
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateVehicule([FromBody] VehicleCreateDTO vehicleCreateDTO) {
			try {
				var response = await _unitOfWork.Vehicle.CreateVehicle(_mapper.Map<Vehicle>(vehicleCreateDTO));
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateVehicule([FromBody] VehicleUpdateDTO vehicleUpdateDTO) {
			try {
				var response = await _unitOfWork.Vehicle.UpdateVehicle(_mapper.Map<Vehicle>(vehicleUpdateDTO));
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}
