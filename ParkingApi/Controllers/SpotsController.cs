using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApi.Models;
using ParkingApi.Repository.IRepository;

namespace ParkingApi.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class SpotsController : ControllerBase {

		private readonly IUnitOfWork _unitOfWork;

		public SpotsController(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		public async Task<IActionResult> RegisterUser() {
			try {
				var response = _unitOfWork.Spot.SetSize(5);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}
