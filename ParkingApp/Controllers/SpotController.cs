using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Data.Repositories;
using ParkingApp.Model;

namespace ParkingApp.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase {

        private readonly ISpotRepository _spotRepository;

        public SpotController(ISpotRepository spotRepository) {
            _spotRepository = spotRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpotStatus() {
            try {
                var response = await _spotRepository.GetSpotStatus();
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpot([FromBody] QuerySpot querySpot) {
            try {
                var response = await _spotRepository.CreateSpot(querySpot.Quantity);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpot([FromBody] SpotUpdate spot) {
            try {
                var response = await _spotRepository.UpdateSpot(spot.Id, spot.Status);
                return StatusCode(200, new { request_status = "successful", response = response });
            } catch (Exception ex) {
                return StatusCode(500, new { request_status = "unsuccessful", response = ex.Message });
            }
        }

    }
}
